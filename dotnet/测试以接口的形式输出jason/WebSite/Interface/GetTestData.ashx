<%@ WebHandler Language="C#" Class="GetTestData" %>

using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

public class GetTestData : IHttpHandler
{
    #region IHttpHandler Members

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/x-json";

        ResponseResult(context);
    }

    public bool IsReusable
    {
        get { return false; }
    }

    #endregion

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