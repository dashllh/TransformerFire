using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerFireApp.Models
{
    internal class SensorData
    {        
        // 油面温度
        internal double OilSurfaceTemp { get; set; } = 0.0;
        // 储油罐内部温度
        internal double OilInnerTemp { get; set; } = 0.0;
        // 雾化区域压力
        internal double AtomizationPressure { get; set; } = 0.0;
        // 热流
        internal double HeatFlow { get; set; } = 0.0;
        // 点火器状态
        internal bool IgniterStatus { get; set; } = false;
    }
}
