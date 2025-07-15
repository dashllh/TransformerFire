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
        internal float OilSurfaceTemp { get; set; } = 0.0F;
        // 储油罐内部温度
        internal float OilInnerTemp { get; set; } = 0.0F;
        // 雾化区域压力
        internal float AtomizationPressure { get; set; } = 0.0F;
        // 热流
        internal float HeatFlow { get; set; } = 0.0F;
        // 点火器状态
        internal bool IgniterStatus { get; set; } = false;
    }
}
