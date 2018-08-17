using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using LynLib.Utils.Winform.LynForm;

namespace 测试生成图片
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            const string aText1 = "FIR-雨樱花";
            const string aDestPath = @"d:\Users\lyn\Desktop\output.jpg";

            var aBitmap = new Bitmap(800, 600, PixelFormat.Format24bppRgb); //设置生成图片大小
            var aGraphics = Graphics.FromImage(aBitmap);
            aGraphics.Clear(Color.FromArgb(255, 190, 200)); //设置生成图片背景色
            aGraphics.SmoothingMode = SmoothingMode.HighQuality;
            aGraphics.InterpolationMode = InterpolationMode.High;
            aGraphics.DrawImage(aBitmap, 0, 0, aBitmap.Width, aBitmap.Height);

            var aFont = new Font("Arial Black", 50, FontStyle.Bold);
            var aBrush = new SolidBrush(Color.FromArgb(255, Color.Red));

            var aSizeF1 = aGraphics.MeasureString(aText1, aFont);

            var aX1 = (aBitmap.Width - aSizeF1.Width)/2;
            var aY1 = (aBitmap.Height - aSizeF1.Height)/2;

            aGraphics.DrawString(aText1, aFont, aBrush, aX1, aY1);

            aBitmap.Save(aDestPath, ImageFormat.Jpeg);

            aGraphics.Dispose();
            aBitmap.Dispose();
        }
    }
}