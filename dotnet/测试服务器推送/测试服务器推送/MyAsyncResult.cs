using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace 测试服务器推送
{
    public class MyAsyncResult : IAsyncResult
    {
        public MyAsyncResult(HttpContext context, AsyncCallback cb, string sessionId)
        {
            SessionId = sessionId;
            Context = context;
            CallBack = cb;
            IsCompleted = true;
        }

        public HttpContext Context { get; set; }
        public AsyncCallback CallBack { get; set; }

        /// <summary>
        ///     自定义标识
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        ///     自定义消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     是否结束请求
        ///     true:完成
        ///     false:阻塞
        /// </summary>
        public bool IsCompleted { get; private set; }

        public WaitHandle AsyncWaitHandle { get; private set; }

        public object AsyncState { get; private set; }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        /// <summary>
        ///     发送消息
        /// </summary>
        /// <param name="iscompleted">确认下发信息</param>
        public void SetCompleted(bool iscompleted)
        {
            if (iscompleted && CallBack != null)
            {
                CallBack(this);
            }
        }
    }
}