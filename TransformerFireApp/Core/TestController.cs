using System.ComponentModel;
using System.Globalization;
using CsvHelper;
using TransformerFireApp.Models;

namespace TransformerFireApp.Core
{
    internal class TestController
    {
        //计时线程
        private readonly System.Threading.Timer _timer;

        private int _counter = 0;
        private List<SensorOutputSnapshot> _lstSensorDataBuffer;

        private TestViewModel _testViewModel;

        private Form _testForm;        

        public TestController(Form testWindow)
        {
            _timer = new(RecordData);
            _testForm = testWindow;
            _testViewModel = new TestViewModel();
            _lstSensorDataBuffer = new List<SensorOutputSnapshot>();
        }

        /* 从全局传感器数据缓存中获取最新传感器数据
           返回值:
                  true - 成功获取传感器最新数据
                  false - 获取最新数据失败
        */
        private bool FetchSensorData()
        {
            var sensorData = GlobalData.Data["SensorOutputSnap"] as SensorOutputSnapshot;
            if (sensorData is not null)
            {
                _testViewModel.TankInnerTemperature = sensorData.TankInnerTemperature;
            }

            return true;
        }

        // 试验数据记录线程函数
        private void RecordData(object status)
        {
            // 获取传感器最新数据,如果获取失败则跳过本轮
            if (!FetchSensorData())
                return;

            // 保存传感器最新数据
            var sensorData = GlobalData.Data["SensorOutputSnap"] as SensorOutputSnapshot;
            if (sensorData is not null) {
                // 将传感器数据快照添加到数据采集缓存列表
                _lstSensorDataBuffer.Add(sensorData);
            }
            else
            {
                // 如果传感器数据快照获取失败,则跳过本轮采集
                return;
            }
            // 更新样品试验视图界面显示
            _testViewModel.Timer = _counter;
            _testForm.UpdateDisplay(_testViewModel);

            // 增加采集计数器
            _counter++;
        }

        public void Start()
        {
            // 清零数据采集计时器
            _counter = 0;
            // 清空数据采集缓存
            _lstSensorDataBuffer.Clear();
            // 设置采集周期为1秒
            _timer.Change(0, 1000);
        }

        public void Stop()
        {
            _timer.Change(0, Timeout.Infinite);
        }

        public void OutputTestData()
        {
            progress.Show();
            progress.Invoke(new Action(() =>
            {
                progress.Update();
            }));

            //_dataModel = AppData.Data?["TestData"] as DataModel;
            //if (_dataModel == null)
            //{
            //    MessageBox.Show("系统未检测到已录入的样品信息,无法生成报告。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            /* 创建本地存储目录 */
            string prodpath = $"D:\\XF 1205-2014 FFire\\{_dataModel.SampleId}";
            string smppath = $"{prodpath}\\{_dataModel.TestId}";
            string datapath = $"{smppath}\\data";
            string rptpath = $"{smppath}\\report";

            try
            {
                /* 创建本次试验结果文件的存储目录 */
                //试验样品根目录
                Directory.CreateDirectory(prodpath);
                //本次试验根目录
                Directory.CreateDirectory(smppath);
                //本次试验原始数据目录
                Directory.CreateDirectory(datapath);
                //本次试验报表目录
                Directory.CreateDirectory(rptpath);

                /* 保存本次试验数据文件 */
                // 使用CsvHelper保存传感器采集数据
                using (var writer = new StreamWriter($"{datapath}\\sensordata.csv", false))
                using (var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    //写入数据内容
                    csvwriter.WriteRecords(_sensorDataBuffer);
                }

                // 使用EPPlus加载csv格式传感器数据
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var format = new ExcelTextFormat()
                {
                    Delimiter = ',',
                    EOL = "\r"    // 修改行尾结束符,默认为 "\r\n" ("\r"为回车符 "\n"为换行符);
                                  // 字符类型引用符 format.TextQualifier = '"';
                };
                using (ExcelPackage excelPack = new ExcelPackage(new FileInfo(@"D:\\XF 1205-2014 FFire\\chart_template.xlsx")))
                {
                    // 加载传感器温度原始数据
                    excelPack.Workbook.Worksheets[0].Cells["A1"].LoadFromText(new FileInfo($"{datapath}\\sensordata.csv"), format,
                        OfficeOpenXml.Table.TableStyles.None, true);
                    // 保存至指定文件夹
                    excelPack.SaveAs($"{datapath}\\chart.xlsx");
                }

                // 加载报表文件并保存温度图表为本地文件
                MSExcel.Application oApp;
                MSExcel.Workbook oWorkbook;
                MSExcel.Worksheet oWorksheet;

                oApp = new MSExcel.Application();
                oApp.Visible = false;
                oApp.DisplayAlerts = false;
                oWorkbook = oApp.Workbooks.OpenXML($"{datapath}\\chart.xlsx");
                oWorksheet = oWorkbook.Worksheets.Item[1];
                // 将图表对象复制到系统剪贴板
                oWorksheet.Shapes.Item(1).Copy();

                oWorkbook.Close(false);
                oApp.Quit();                

                progress.Invoke(new Action(() =>
                {
                    progress.Close();
                }));

                MessageBox.Show("生成报告成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "系统异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 重置试验控制变量
            _counter = 0;
            // 清空采集数据缓存
            _lstSensorDataBuffer.Clear();
            // 重置试验界面显示
            _testForm.ResetDisplay();
        }
    }
}
}
