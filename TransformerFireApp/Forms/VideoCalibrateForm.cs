using Emgu.CV;
using Emgu.CV.CvEnum;
using TransformerFireApp.Models;
using TransformerFireApp.Core;

namespace TransformerFireApp
{
    public partial class VideoCalibrateForm : Form
    {
        VideoCapture videoCapture;
        public VideoCalibrateForm()
        {
            InitializeComponent();
        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Mat threshold = new Mat();
            videoCapture.Retrieve(frame);
            // 进行图像处理
            CvInvoke.Threshold(frame, threshold,180,255,ThresholdType.Binary);
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
        }

        private void btnCloseVideo_Click(object sender, EventArgs e)
        {
            if(videoCapture.IsOpened)
            {
                videoCapture.Stop();
                videoCapture.Dispose();
                videoCapture = null;
                // 清除图片显示
                picOrigin.Image = null;
                picThreshHold.Image = null;
            }
        }
    }
}
