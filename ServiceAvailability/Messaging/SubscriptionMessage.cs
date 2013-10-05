using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat.Messaging {
    [Serializable]
    public class SubscriptionMessage : BaseMessage {
        public SubscriptionMessageType RequestType { get; set; }
    }
}
