using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace TransformerFireApp.Core
{
    internal class FireDetect
    {
        Size targetSize;
        private double _distanceIndex = 0.0; // 距离转换系数，单位为米/像素
        private Rectangle _fireArea;      // 用于存储火焰检测区域的边界框

        public double DistanceIndex
        {
            get { return _distanceIndex; }
            set { _distanceIndex = value; }
        }
        public Rectangle FireArea
        {
            get { return _fireArea; }
            set { _fireArea = value; }
        }
        public FireDetect()
        {
            targetSize = new Size(640, 480);
        }

        internal float Measuring(Mat frame)
        {
            Mat resizedFrame = new Mat();
            Mat gray = new Mat();
            Mat binary = new Mat();
            Mat hierarchy = new Mat();
            // 缩小图片
            CvInvoke.Resize(frame, resizedFrame, targetSize, 0, 0, Inter.Linear);
            // 获取ROI区域
            resizedFrame = new Mat(resizedFrame, _fireArea);
            // 高斯模糊
            CvInvoke.GaussianBlur(resizedFrame, resizedFrame, new Size(3, 3), 0);
            // 转为灰度图
            CvInvoke.CvtColor(resizedFrame, gray, ColorConversion.Bgr2Gray);
            // 二值化
            CvInvoke.Threshold(gray, binary, 230, 255, ThresholdType.Binary);
            // 查找最外层轮廓
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(binary,contours,hierarchy,RetrType.External,ChainApproxMethod.ChainApproxSimple);

            // 寻找最大轮廓
            int maxContourIndex = -1;
            double maxArea = 0;
            for (int i = 0; i < contours.Size; i++)
            {
                double area = CvInvoke.ContourArea(contours[i]);
                if (area > maxArea)
                {
                    maxArea = area;
                    maxContourIndex = i;
                }
            }

            // 处理最大轮廓
            if (maxContourIndex >= 0)
            {
                Rectangle rect = CvInvoke.BoundingRectangle(contours[maxContourIndex]);

                // 绘制绿色边界框（在resizedFrame上操作）
                CvInvoke.Rectangle(resizedFrame,rect,new MCvScalar(0, 255, 0),2);
                // 显示高度信息
                CvInvoke.PutText(
                    resizedFrame,
                    $"H:{rect.Height}px",
                    new Point(rect.X, rect.Y - 10),
                    FontFace.HersheySimplex,
                    0.5,
                    new MCvScalar(0, 255, 0),
                    1);
                return rect.Height; // 返回高度
            }
            // 如果没有找到轮廓，返回-1
            return -1;
        }
    }
}
