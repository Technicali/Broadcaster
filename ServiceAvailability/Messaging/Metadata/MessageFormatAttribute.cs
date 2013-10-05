using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat.Messaging.Metadata {
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Interface,
        AllowMultiple = false,
        Inherited = true)]
    class MessageFormatAttribute : Attribute {

        public MessageFormatAttribute() : this(MessageFormatType.Binary) {
        }

        public MessageFormatAttribute(MessageFormatType formatType) {
            if (Enum.IsDefined(typeof(MessageFormatType), formatType)) {
                Value = formatType;
            }
            else {
                Value = MessageFormatType.Binary;
            }
        }

        public MessageFormatType Value { get; private set; }
    }
}
