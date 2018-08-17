using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 测试服务器推送
{
    public class MyHandler : IHttpHandler
    {
        /// <summary>
        ///     消息下发请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //不让客户端缓存
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var userlist = MyAsyncHandler.Queue;

            //唯一标识
            var sessionId = context.Request.QueryString["sessionId"];

            //消息内容
            var message = context.Request.QueryString["message"] + "    " + userlist.Count.ToString();

            var error = new List<string>();

            foreach (var res in userlist)
            {
                //如果不是自己就推送信息
                if (res.SessionId != sessionId)
                {
                    res.Message = message;
                    try
                    {
                        //推送内容
                        res.SetCompleted(true);
                    }
                    catch (Exception)
                    {
                        //如果推送失败（客户端已断开，网络异常等）
                        //则删除该标志
                        error.Add(res.SessionId);
                    }
                }
            }

            foreach (var v in error)
            {
                userlist.RemoveAll(fun => fun.SessionId == v);
            }
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}