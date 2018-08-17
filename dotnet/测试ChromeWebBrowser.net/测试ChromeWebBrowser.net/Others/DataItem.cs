using System.Collections.Generic;

namespace 测试ChromeWebBrowser.net.Others
{
    public class DataItem
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public static List<DataItem> GetList(int pCount)
        {
            var aList = new List<DataItem>(pCount);
            for (var i = 1; i <= pCount; i++)
            {
                var aDataItem = new DataItem();
                aDataItem.Text = string.Format("Text_{0}", i);
                aDataItem.Value = string.Format("Value_{0}", i);
                aList.Add(aDataItem);
            }
            return aList;
        }

        public static List<DataItem> GetList()
        {
            return GetList(10);
        }
    }
}