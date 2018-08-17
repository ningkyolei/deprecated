using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 测试服务器推送
{
    public class MyAsyncHandler : IHttpAsyncHandler
    {
        public static List<MyAsyncResult> Queue = new List<MyAsyncResult>();

        public void ProcessRequest(HttpContext context)
        {
        }

        public bool IsReusable
        {
            get { return true; }
        }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            //接到连接请求

            //不让客户端缓存
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            //获取唯一标识
            var sessionId = context.Request.QueryString["sessionId"];

            if (Queue.Count(fun => fun.SessionId == sessionId) > 0)
            {
                var index = Queue.IndexOf(Queue.Find(fun => fun.SessionId == sessionId));
                Queue[index].Context = context;
                Queue[index].CallBack = cb;
                return Queue[index];
            }

            //如果不存在则加入队列
            var asyncResult = new MyAsyncResult(context, cb, sessionId);
            Queue.Add(asyncResult);
            return asyncResult;
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            //长连接结束前写入内容
            var rslt = (MyAsyncResult)result;

            //拼装返回内容
            rslt.Context.Response.Write(rslt.Message);
            rslt.Message = string.Empty;
        }
    }
}