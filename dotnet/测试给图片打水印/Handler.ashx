<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        GenImage(context);
    }

    public void GenImage(HttpContext context)
    {
        var aSrcPath = context.Server.MapPath("images/mother_beat_me_again.jpg");
        const string aDestPath = @"D:\Users\leiyining\Desktop\test.jpg";
        try
        {
            var aImage = Image.FromFile(aSrcPath);
            var aBitmap = new Bitmap(aImage.Width, aImage.Height, PixelFormat.Format24bppRgb);
            var aGraphics = Graphics.FromImage(aBitmap);
            aGraphics.Clear(Color.White);
            aGraphics.SmoothingMode = SmoothingMode.HighQuality;
            aGraphics.InterpolationMode = InterpolationMode.High;
            aGraphics.DrawImage(aImage, 0, 0, aImage.Width, aImage.Height);

            const string aText = "hello!";
            var aFont = new Font("Arial Black", 30, FontStyle.Bold);
            var aBrush = new SolidBrush(Color.FromArgb(255, Color.Red));
            aGraphics.DrawString(aText, aFont, aBrush, 0, 0);

            aBitmap.Save(aDestPath);

            aGraphics.Dispose();
            aBitmap.Dispose();
            aImage.Dispose();
        }
        catch (Exception ex)
        {
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}