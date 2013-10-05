using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat {
    public interface IListener<TMessage> where TMessage : IMessage {
        TMessage Receive();
        TMessage Receive(TimeSpan receiveTimeout);
    }
}
