using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging;

namespace Broadcaster.ServiceHeartbeat {
    public interface IEndpoint 
    {
        string OwnerName { get; }
        string Address { get; }
        IEnumerable<Type> AcceptedMessageTypes { get; }
    }
}
