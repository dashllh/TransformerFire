using FluentModbus;
using System.IO.Ports;

namespace TransformerFireApp.Core
{
    internal class Apparatus
    {
        // 温度模块通信对象
        private ModbusRtuClient _modbusClient;
        // 数据采集接口
        private string _comPort { get; set; } = string.Empty;
        // 摄像机接口
        private string _rtspAddress { get; set; } = string.Empty;
        // 数据采集对象
        private DAQ _Daq { get; set; }
        // 摄像头对象
        private FireDetect _fireDetect { get; set; }
        public Apparatus()
        {
            _Daq = new DAQ();
            // 初始化设备连接对象
            _modbusClient = new();
            _modbusClient.BaudRate = 9600;
            _modbusClient.Parity = Parity.None;
            _modbusClient.StopBits = StopBits.One;
            _modbusClient.ReadTimeout = 5000;
            _modbusClient.WriteTimeout = 5000;
        }

        /* 设备动作接口函数 */
        // 初始化设备连接
        internal bool InitailizeConnection(string port,string rtsp)
        {
            _comPort = port;
            _rtspAddress = rtsp;
            try
            {
                // 连接Modbus设备
                _modbusClient.Connect(_comPort, ModbusEndianness.BigEndian);
                if (!_modbusClient.IsConnected)
                {
                    // 温度模块连接失败
                    return false;
                }

                // 连接摄像头
                // ...
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;
        }
        // 检查设备连接状态
        internal bool GetApparatusConnectionStatus()
        {
            return _modbusClient.IsConnected;
        }
        // 启动数据采集
        internal void StartDAQ()
        {
            _Daq.StartDAQ();
        }
        // 停止数据采集
        internal void StopDAQ()
        {
            _Daq.StopDAQ();
        }
        // 打开点火器
        internal bool OpenIgniter()
        {
            return false;
        }
        // 关闭点火器
        internal bool CloseIgniter()
        {
            return false;
        }
        // 开始加热
        internal bool StartHeater()
        {
            return false;
        }
        // 停止加热
        public bool StopHeater()
        {
            return false;
        }
    }
}
