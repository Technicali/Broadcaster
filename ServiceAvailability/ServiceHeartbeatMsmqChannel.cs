using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;

namespace Broadcaster.ServiceHeartbeat {
    class ServiceHeartbeatMsmqChannel : MsmqChannel<ServiceHeartbeatMessage> {
        public ServiceHeartbeatMsmqChannel(IEndpoint ownerEndpoint, MessageFormatType expectedMessageFormat)
            : base(ownerEndpoint, expectedMessageFormat) {
        }
    }
}
