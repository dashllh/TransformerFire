using TransformerFireApp.Core;
using TransformerFireApp.Models;
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

            SensorData sensorData = new SensorData();
            Apparatus apparatus = new Apparatus();            

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
                MessageBox.Show("应用程序配置项数据设置错误，请检查文件!\n" + e.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            // 初始化应用程序全局对象
            GlobalData.Data = new Dictionary<string, object>();
            GlobalData.Data.Add("SensorData", sensorData);
            GlobalData.Data.Add("Apparatus", apparatus);

            if (apparatus.InitailizeConnection(string.Empty,string.Empty))
            {
                // 启动传感器数据采集
                apparatus.StartDAQ();
            }            
            
            Application.Run(new MainWindow());
        }
    }
}