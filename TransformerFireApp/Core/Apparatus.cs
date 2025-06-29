using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TransformerFireApp.Core
{
    internal class Apparatus
    {
        // 数据采集接口
        internal string SensorDataConnection { get; set; } = string.Empty;
        // 摄像机接口
        internal string VideoConnection { get; set; } = string.Empty;
        // 数据采集对象
        internal DAQ Daq { get; set; }

        public Apparatus()
        {
            Daq = new DAQ();
        }

        /* 设备动作接口函数 */
        // 初始化设备连接
        internal bool InitailizeConnection()
        {
            return false;
        }
        // 检查设备连接状态
        internal bool CheckApparatusConnectionStatus()
        {
            return false;
        }
        // 启动数据采集
        internal void StartDAQ()
        {
            Daq.StartDAQ();
        }
        // 停止数据采集
        internal void StopDAQ()
        {
            Daq.StopDAQ();
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
