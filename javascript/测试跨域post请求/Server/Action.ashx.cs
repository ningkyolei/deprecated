using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace Server
{
    /// <summary>
    /// Action 的摘要说明
    /// </summary>
    public class Action : IHttpHandler
    {
        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/x-json";
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //context.Response.AddHeader("Access-Control-Allow-Headers", "X-Requested-With");

            var aEmail = context.Request.Form["email"];
            var aPassword = context.Request.Form["password"];

            //ResponseResult(context);

            var aList = DataItem.GetList(9);

            var aResult = new ClientResult();
            aResult.DataList = aList;
            aResult.Email = aEmail;
            aResult.Password = aPassword;

            var aResultString = JsonConvert.SerializeObject(aResult);

            context.Response.Write(aResultString);
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
            public string Email { get; set; }
            public string Password { get; set; }
        }

        #endregion
    }
}