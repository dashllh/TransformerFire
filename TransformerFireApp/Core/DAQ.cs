using TransformerFireApp.Models;

namespace TransformerFireApp.Core
{
    internal class DAQ
    {
        private readonly System.Threading.Timer _timer;
        public DAQ()
        {
            _timer = new System.Threading.Timer(RefreshSensorData);
            _timer.Change(0, Timeout.Infinite);
        }

        private void RefreshSensorData(object? status)
        {
            var _sensorData = GlobalData.Data?["SensorData"] as SensorData;            
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
