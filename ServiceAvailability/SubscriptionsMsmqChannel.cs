using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;

namespace Broadcaster.ServiceHeartbeat {
    class SubscriptionsMsmqChannel : MsmqChannel<SubscriptionMessage> {

        public SubscriptionsMsmqChannel(IEndpoint endpoint, MessageFormatType expectedMessageFormat)
            :base(endpoint, expectedMessageFormat) {
        }
    }
}
