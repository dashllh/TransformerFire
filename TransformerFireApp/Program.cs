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

            // ��ȡ�����ļ���Ӧ��,��������Ӧ��Object instance
            try
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();
                
                // ���豸���Ӳ���
                config.GetSection("apparatus").Bind(apparatus);
                // ����Ĭ��������Ϣ
                //config.GetSection("defaultvalue").Bind(dataModel);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ӧ�ó����������������ô���,�����ļ�!\n" + e.Message, "ϵͳ�쳣", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            if (apparatus.InitailizeConnection(string.Empty,string.Empty))
            {
                // ���������豸���ݲɼ�
                apparatus.StartDAQ();
            }

            // ��ʼ��Ӧ�ó���ȫ�ִ洢
            GlobalData.Data = new Dictionary<string, object>();
            GlobalData.Data?.Add("SensorData", sensorData);
            GlobalData.Data?.Add("Apparatus", apparatus);
            
            Application.Run(new MainWindow());
        }
    }
}