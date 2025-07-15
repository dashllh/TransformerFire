using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerFireApp.Models
{
    internal class SensorOutputSnapshot
    {        
        // 油面温度
        internal double TankSurfaceTemperature { get; set; } = 0.0;
        // 储油罐内部温度
        internal double TankInnerTemperature { get; set; } = 0.0;
        // 雾化区域压力
        internal double AtomizationPressure { get; set; } = 0.0;
        // 热流
        internal double HeatFlow { get; set; } = 0.0;
        // 点火器状态
        internal bool IgniterStatus { get; set; } = false;
    }
}
