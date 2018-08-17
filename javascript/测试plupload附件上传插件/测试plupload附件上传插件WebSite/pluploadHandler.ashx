<%@ WebHandler Language="C#" Class="pluploadHandler" %>

using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

public class pluploadHandler : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Cache.SetNoStore();

        if (context.Request.Files.Count > 0)
        {
            var aOne = context.Request["one"];//NOTE:通过这种方式来获取post过来的数据

            var aHttpPostedFile = context.Request.Files[0];//NOTE:通过这种方式来获取用户上传的文件

            //aHttpPostedFile.SaveAs(aFileFullPath);//TODO:通过这种方式将上传的文件保存到服务器

            ResponseResult(context);
        }

    }

    public bool IsReusable
    {
        get { return false; }
    }

    private static void ResponseResult(HttpContext context)
    {
        var aList = DataItem.GetList(9);

        var aResult = new ClientResult();
        aResult.DataList = aList;

        var aResultString = JsonConvert.SerializeObject(aResult);

        context.Response.Write(aResultString);
    }

    private class DataItem
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static List<DataItem> GetList(int pCount)
        {
            var aList = new List<DataItem>(pCount);
            for (int i = 0; i < pCount; i++)
            {
                var aDataItem = new DataItem();
                aDataItem.Id = string.Format("Id_{0}", i);
                aDataItem.Name = string.Format("Name_{0}", i);
                aList.Add(aDataItem);
            }
            return aList;

        }
    }

    #region Nested type: ThisResult

    private class ClientResult
    {
        public List<DataItem> DataList { get; set; }
    }

    #endregion
}