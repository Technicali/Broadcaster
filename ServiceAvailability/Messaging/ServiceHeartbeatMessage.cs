using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;
using System.Messaging;

namespace Broadcaster.ServiceHeartbeat.Messaging {

    [Serializable]
    [Priority(MessagePriority.Low)]
    [TimeToBeReceived("00:00:02")]
    public class ServiceHeartbeatMessage : BaseMessage {
        public DateTime HeartbeatTime { get; set; }
        public TimeSpan Validity { get; set; }
        public ServiceStatus Status { get; set; }
    }
}
