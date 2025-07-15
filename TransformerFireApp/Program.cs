using TransformerFireApp.Core;
using TransformerFireApp.Models;
using TransformerFireApp.DBContext;
using Microsoft.Extensions.Configuration;

namespace TransformerFireApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            SensorOutputSnapshot sensorSnap = new SensorOutputSnapshot();
            Apparatus apparatus = new Apparatus();
            FireDetect fireDetect = new FireDetect();
            Dictionary<int, Sensor> dictSensor;
            // 初始化数据库上下文
            using (var dbContext = new AppDBContext())
            {
                // 确保数据库已创建
                dbContext.Database.EnsureCreated();
                // 初始化传感器数据
                dictSensor = dbContext.Sensors.ToDictionary(s => s.Id, s => s);
                // 从数据库获取距离系数
                var distIndexRecord = dbContext.CalibrationValues
                                .FirstOrDefault(c => c.ParamName == "dist_index");
                if (distIndexRecord != null && double.TryParse(distIndexRecord.ParamValue, out double distIndex))
                {                    
                    fireDetect.DistanceIndex = distIndex;
                }
                else
                {
                    MessageBox.Show("距离系数配置项格式错误，请检查数据库设置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                // 从数据库获取火灾区域
                var fireAreaRecord = dbContext.CalibrationValues
                            .FirstOrDefault(c => c.ParamName == "fire_area");
                if (fireAreaRecord != null)
                {
                    // 解析火灾区域参数
                    string[] parts = fireAreaRecord.ParamValue.Split(',');
                    if (parts.Length == 4 &&
                        int.TryParse(parts[0], out int x) &&
                        int.TryParse(parts[1], out int y) &&
                        int.TryParse(parts[2], out int width) &&
                        int.TryParse(parts[3], out int height))
                    {
                        fireDetect.FireArea = new Rectangle(x, y, width, height);
                    }
                    else
                    {
                        MessageBox.Show("火灾区域配置项格式错误，请检查数据库设置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                }
            }

            // 获取配置文件对应项并绑定至对应的Object instance
            try
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();
                
                config.GetSection("apparatus").Bind(apparatus);
                //config.GetSection("defaultvalue").Bind(dataModel);
            }
            catch (Exception e)
            {
                MessageBox.Show("读取应用程序配置文件错误，请检查文件!\n" + e.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            // 初始化应用程序全局对象
            GlobalData.Data = new Dictionary<string, object>();
            GlobalData.Data.Add("Sensors", dictSensor);
            GlobalData.Data.Add("SensorOutputSnap", sensorSnap);
            GlobalData.Data.Add("Apparatus", apparatus);
            GlobalData.Data.Add("FireDetect", fireDetect);

            if (apparatus.InitailizeConnection(string.Empty,string.Empty))
            {
                // 启动传感器数据采集
                apparatus.StartDAQ();
            }            
            
            Application.Run(new MainWindow());
        }
    }
}