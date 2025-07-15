using TransformerFireApp.Models;

namespace TransformerFireApp.Core
{
    internal class DAQ
    {
        private readonly System.Threading.Timer _timer;
        public DAQ()
        {
            _timer = new System.Threading.Timer(RefreshSensorData);
        }

        private void RefreshSensorData(object status)
        {
            var _sensorSnap = GlobalData.Data["SensorOutputSnap"] as SensorOutputSnapshot;
            var _sensors = GlobalData.Data["Sensors"] as Dictionary<int, Sensor>;
            // 获取传感器最新采集数据
            _sensors[0].CurrentSignal = 100.0f; // 模拟传感器数据更新
            _sensors[1].CurrentSignal = 200.0f; // 模拟传感器数据更新
            _sensors[2].CurrentSignal = 300.0f; // 模拟传感器数据更新
            // 更新传感器当前值快照
            _sensorSnap.TankInnerTemperature = _sensors[0].CurrentOutput;
            _sensorSnap.TankSurfaceTemperature = _sensors[1].CurrentOutput;
            _sensorSnap.AtomizationPressure = _sensors[2].CurrentOutput;
        }

        public void StartDAQ()
        {
            _timer.Change(0, 1000);
        }

        public void StopDAQ()
        {
            _timer.Change(0, Timeout.Infinite);
        }
    }
}
