<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.IO;
using System.Web;

public class Handler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/JPEG";

        var aSrcPath = context.Server.MapPath("images/mother_beat_me_again.jpg");
        var aFileStream = new FileStream(aSrcPath, FileMode.Open, FileAccess.Read);
        var aByteArray = new byte[aFileStream.Length];
        var aLength = Convert.ToInt32(aFileStream.Length);
        aFileStream.Read(aByteArray, 0, aLength);
        aFileStream.Close();
        context.Response.OutputStream.Write(aByteArray, 0, aLength);
        context.Response.End();
    }

    public bool IsReusable
    {
        get { return false; }
    }
}