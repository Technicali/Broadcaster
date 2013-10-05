using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Broadcaster.ServiceHeartbeat {
    class MsmqDispatcher<TMessage> : IDispatcher<TMessage> where TMessage : IMessage {

        #region IDispatcher<TMessage> Members

        public void Send(TMessage message) {
            MsmqChannelHelper.Send(message, MsmqChannelHelper.GetMessageQueue(message.From.Address));
        }

        public void Send(TMessage message, TimeSpan timeout) {
            ManualResetEvent waitHandle = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem((o) => {
                Send(message);
                waitHandle.Set();
            });

            waitHandle.WaitOne(timeout);
        }

        #endregion
    }
}
