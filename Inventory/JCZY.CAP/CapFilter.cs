using DotNetCore.CAP.Filter;
using JCZY.CAP.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCZY.CAP
{
    public class CapFilter : SubscribeFilter
    {
        private readonly IMessageTracker _messageTracker;

        public CapFilter(IMessageTracker messageTracker)
        {
            _messageTracker = messageTracker;
        }

        public override async Task OnSubscribeExecutingAsync(ExecutingContext context)
        {
            // 订阅方法执行前
            var msg = context.DeliverMessage;
            //var msgId = msg.Headers[""]
        }

        public override async Task OnSubscribeExecutedAsync(ExecutedContext context)
        {
            // 订阅方法执行后
            var msgId = context.MediumMessage;
            var msg = context.DeliverMessage;
        }

        public override async Task OnSubscribeExceptionAsync(ExceptionContext context)
        {
            // 订阅方法执行异常
        }
    }
}
