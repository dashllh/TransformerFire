using Emgu.CV;
using Emgu.CV.CvEnum;
using TransformerFireApp.Models;
using TransformerFireApp.Core;
using TransformerFireApp.Forms;
using TransformerFireApp.DBContext;

namespace TransformerFireApp
{
    public partial class VideoCalibrateForm : Form
    {
        VideoCapture videoCapture;
        Point ptStart;
        Point ptEnd;
        Rectangle rectFire;
        private enum CalibrationMode
        {
            DistIndex,
            FireArea,
        }
        CalibrationMode CaliMode = CalibrationMode.DistIndex;
        bool IsCalibrating = false;

        FireDetect fireDetect;
        bool isDetecting = false;
        public VideoCalibrateForm()
        {
            InitializeComponent();
            fireDetect = new FireDetect();
        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Mat threshold = new Mat();
            videoCapture.Retrieve(frame);
            if (isDetecting)
            {
                // 进行图像预处理
                CvInvoke.Threshold(frame, threshold, 180, 255, ThresholdType.Binary);
                // 进行火灾检测
                float height = fireDetect.Measuring(frame);
            }
            // 显示测量结果
            picOrigin.Image = frame.ToBitmap();
            picThreshHold.Image = threshold.ToBitmap();
        }

        private void btnOpenVideo_Click(object sender, EventArgs e)
        {
            var _apparatus = GlobalData.Data["Apparatus"] as Apparatus;
            //videoCapture = new VideoCapture(_apparatus?.VideoConnection);     
            videoCapture = new VideoCapture(0);
            videoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
            videoCapture.Start();
            // 设置测量功能按钮为可用状态
            btnCheckResult.Enabled = true;
            // 更新按钮状态
            btnCloseVideo.Enabled = true;
            btnOpenVideo.Enabled = false;
        }

        private void btnCloseVideo_Click(object sender, EventArgs e)
        {
            if (videoCapture is null)
                return;
            // 停止视频捕获并关闭摄像头
            if (videoCapture.IsOpened)
            {
                videoCapture.Stop();
                videoCapture.Dispose();
                videoCapture = null;
                // 清除图片显示
                picOrigin.Image = null;
                picThreshHold.Image = null;
            }
            // 重置测量状态及按钮显示
            isDetecting = false;
            btnCheckResult.Enabled = false;
            btnCheckResult.Text = "开始检测";
            btnCloseVideo.Enabled = false;
            btnOpenVideo.Enabled = true;
        }

        private void picOrigin_MouseClick(object sender, MouseEventArgs e)
        {
            // 如果是右键单击，则退出标定模式
            if (e.Button == MouseButtons.Right)
            {
                IsCalibrating = false;
                ptStart = Point.Empty;
                ptEnd = Point.Empty;
                rectFire = Rectangle.Empty;
                picOrigin.Invalidate();
                return;
            }
            if (IsCalibrating is false)
            {
                // 第一次点击，记录起点
                ptStart = e.Location;
                IsCalibrating = true;
            }
            else
            {
                // 第二次点击，记录终点
                ptEnd = e.Location;
                // 弹出对话框,输入实际距离并计算距离系数
                if (CaliMode == CalibrationMode.DistIndex)
                {
                    DistInputForm distForm = new DistInputForm();
                    var ret = distForm.ShowDialog(this);
                    if (ret == DialogResult.OK)
                    {
                        float physicalDistance = distForm.PhysicalDistance;
                        // 计算距离系数
                        float distanceIndex = physicalDistance / Math.Abs(ptEnd.Y - ptStart.Y);
                        // 更新火焰检测对象的距离系数
                        var _fireDetect = GlobalData.Data["FireDetect"] as FireDetect;
                        _fireDetect.DistanceIndex = distanceIndex;
                        // 更新界面显示
                        lblDistIndex.Text = $"{distanceIndex:F4}";
                        // 利用AppDBContext将最新距离系数保存至数据库
                        using (var dbContext = new AppDBContext())
                        {
                            // 查找 ParamName 为 "dist_index" 的记录
                            var distIndexRecord = dbContext.CalibrationValues
                                .FirstOrDefault(c => c.ParamName == "dist_index");

                            if (distIndexRecord != null)
                            {
                                // 更新已有记录
                                distIndexRecord.ParamValue = distanceIndex.ToString("F4");
                                dbContext.Update(distIndexRecord);
                                dbContext.SaveChanges();
                                // 显示成功消息
                                MessageBox.Show($"距离系数已设置为: {distanceIndex:F4}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // 如果没有找到记录，提示错误消息
                                MessageBox.Show("未找到距离系数配置条目，请检查数据库设置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                if (CaliMode == CalibrationMode.FireArea)
                {
                    // 计算火灾区域矩形并保存至数据库
                    rectFire = new Rectangle(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                    // 这里可以将rectFire保存到数据库或全局数据中
                    var _fireDetect = GlobalData.Data["FireDetect"] as FireDetect;
                    _fireDetect.FireArea = rectFire;
                    // 利用AppDBContext将火灾区域保存至数据库
                    using (var dbContext = new AppDBContext())
                    {
                        // 查找 ParamName 为 "fire_area" 的记录
                        var fireAreaRecord = dbContext.CalibrationValues
                            .FirstOrDefault(c => c.ParamName == "fire_area");
                        if (fireAreaRecord != null)
                        {
                            // 更新已有记录
                            fireAreaRecord.ParamValue = $"{rectFire.X},{rectFire.Y},{rectFire.Width},{rectFire.Height}";
                            dbContext.Update(fireAreaRecord);
                            dbContext.SaveChanges();
                            // 显示成功消息
                            MessageBox.Show($"火灾区域已设置为: {rectFire}", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // 如果没有找到记录，提示错误消息
                            MessageBox.Show("未找到火灾区域配置条目，请检查数据库设置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                IsCalibrating = false;
            }
        }
        private void picOrigin_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCalibrating)
            {
                // 绘制动态直线
                ptEnd = e.Location;
                picOrigin.Invalidate();
            }
        }

        private void picOrigin_Paint(object sender, PaintEventArgs e)
        {
            // 绘制从ptStart到ptEnd的直线
            if (IsCalibrating)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    // 根据标定模式绘制直线或者矩形
                    if (CaliMode == CalibrationMode.DistIndex)
                    {
                        // 绘制距离标定直线
                        e.Graphics.DrawLine(pen, ptStart, ptEnd);
                    }
                    else if (CaliMode == CalibrationMode.FireArea)
                    {
                        // 绘制火灾区域矩形
                        rectFire = new Rectangle(ptStart.X, ptStart.Y, ptEnd.X - ptStart.X, ptEnd.Y - ptStart.Y);
                        e.Graphics.DrawRectangle(pen, rectFire);
                    }
                }
            }
        }

        private void rdoDistIndex_CheckedChanged(object sender, EventArgs e)
        {
            CaliMode = CalibrationMode.DistIndex;
        }

        private void rdoFireArea_CheckedChanged(object sender, EventArgs e)
        {
            CaliMode = CalibrationMode.FireArea;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            // 如果摄像头正在工作，先停止视频捕获并关闭摄像头，最后关闭窗体
            if (videoCapture != null && videoCapture.IsOpened)
            {
                videoCapture.Stop();
                videoCapture.Dispose();
                videoCapture = null;
                picOrigin.Image = null;
                picThreshHold.Image = null;
            }
            this.Close();
        }

        private void btnCheckResult_Click(object sender, EventArgs e)
        {
            isDetecting = !isDetecting;
            btnCheckResult.Text = isDetecting ? "停止检测" : "开始检测";
        }

        private void VideoCalibrateForm_Load(object sender, EventArgs e)
        {
            // 将当前距离系数显示到标签上
            var _fireDetect = GlobalData.Data["FireDetect"] as FireDetect;
            if (_fireDetect != null)
            {
                lblDistIndex.Text = $"{_fireDetect.DistanceIndex:F4}";
            }
            else
            {
                lblDistIndex.Text = "8888";
            }
        }
    }
}
