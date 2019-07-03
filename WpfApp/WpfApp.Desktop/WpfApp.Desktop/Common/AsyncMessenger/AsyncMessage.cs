using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace WpfApp.Desktop.Common.AsyncMessenger
{
    /// <summary>
    /// awaitable message
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public class AsyncMessage<TMessage> : MessageBase
        where TMessage : MessageBase
    {
        private readonly TaskCompletionSource<object> source = new TaskCompletionSource<object>();
        public TMessage InnerMessage { get; }

        public Task<object> Task => this.source.Task;

        public AsyncMessage(TMessage innerMessage)
        {
            this.InnerMessage = innerMessage;
        }

        public void SetResult(object result)
        {
            this.source.SetResult(result);
        }

        public void SetException(Exception ex)
        {
            this.source.SetException(ex);
        }
    }
}
