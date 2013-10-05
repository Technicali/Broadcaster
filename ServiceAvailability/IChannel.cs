using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging;

namespace Broadcaster.ServiceHeartbeat {
    public interface IChannel<TMessage> where TMessage : IMessage {
        IDispatcher<TMessage> Dispatcher { get; }
        IListener<TMessage> Listener { get; }
    }
}
