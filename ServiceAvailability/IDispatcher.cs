using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat {
    public interface IDispatcher<TMessage> where TMessage : IMessage {
        void Send(TMessage message);
        void Send(TMessage message, TimeSpan sendTimeout);
    }
}
