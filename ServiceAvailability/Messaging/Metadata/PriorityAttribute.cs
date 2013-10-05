using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace Broadcaster.ServiceHeartbeat.Messaging.Metadata {
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Interface,
        AllowMultiple = false,
        Inherited = true)]
    class PriorityAttribute : Attribute {

        public PriorityAttribute() : this(MessagePriority.Normal) {
        }

        public PriorityAttribute(MessagePriority messagePriority) {
            if (Enum.IsDefined(typeof(MessagePriority), messagePriority)) {
                Value = messagePriority;
            }
            else {
                Value = MessagePriority.Normal;
            }
        }

        public MessagePriority Value { get; private set; }

    }
}
