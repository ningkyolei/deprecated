<%@ WebHandler Language="C#" Class="Handler" %>

using System.Web;

public class Handler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        //获取回调函数名
        var aCallback = context.Request.QueryString["callback"];
        //json数据
        const string aJson = "{\"name\":\"chopper\",\"sex\":\"man\"}";

        context.Response.ContentType = "application/json";
        //输出：回调函数名(json数据)
        context.Response.Write(string.Format("{0}({1})", aCallback, aJson));
    }

    public bool IsReusable
    {
        get { return false; }
    }
}