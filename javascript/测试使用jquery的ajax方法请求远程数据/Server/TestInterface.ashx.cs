using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace Server
{
    /// <summary>
    ///     TestInterface 的摘要说明
    /// </summary>
    public class TestInterface : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json;utf-8";

            #region 获取post过来的参数

            string aText = TypeConvertHelper.ToString(context.Request["Text"]);
            string aPagerString = TypeConvertHelper.ToString(context.Request["Pager"]);
            ;
            Pager aPager = null;
            if (!string.IsNullOrWhiteSpace(aPagerString))
            {
                aPager = JsonConvert.DeserializeObject<Pager>(aPagerString);
                    //反序列化jason时，属性不区分大小写！不过建议类属性跟jason对象的属性大小写相一致
            }

            #endregion

            #region 将数据以jason格式传递给客户端

            //obj list to jason
            List<DataItem> aList = DataItem.GetList(9);
            string aJason = JsonConvert.SerializeObject(aList);
            context.Response.Write(aJason);

            #endregion

            ////jason to obj
            //string aJason =
            //    "[{'Text':'Text_1','Value':'Value_1'},{'Text':'Text_2','Value':'Value_2'},{'Text':'Text_3','Value':'Value_3'},{'Text':'Text_4','Value':'Value_4'},{'Text':'Text_5','Value':'Value_5'},{'Text':'Text_6','Value':'Value_6'},{'Text':'Text_7','Value':'Value_7'},{'Text':'Text_8','Value':'Value_8'},{'Text':'Text_9','Value':'Value_9'}]";
            //var aList = JsonConvert.DeserializeObject<List<Item>>(aJason);
        }

        public bool IsReusable
        {
            get { return false; }
        }

        private class DataItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public static List<DataItem> GetList(int pCount)
            {
                var aList = new List<DataItem>(pCount);
                for (int i = 1; i <= pCount; i++)
                {
                    var aItem = new DataItem();
                    aItem.Text = string.Format("Text_{0}", i);
                    aItem.Value = string.Format("Value_{0}", i);
                    aList.Add(aItem);
                }
                return aList;
            }
        }

        private class Pager
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public string Msg { get; set; }
        }

        private static class TypeConvertHelper
        {
            public static string ToString(object o)
            {
                string aReturnValue = string.Empty;
                if (o != null)
                {
                    aReturnValue = o.ToString();
                }
                return aReturnValue;
            }
        }
    }
}