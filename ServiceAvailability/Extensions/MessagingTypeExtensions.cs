using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;
using System.Messaging;

namespace Broadcaster.ServiceHeartbeat.Extensions {

    static class MessagingTypeExtensions {

        public static IMessageFormatter GetMessageFormatter(this MessageFormatType formatType) {
            
            IMessageFormatter formatter = null;
            switch (formatType) {
                case MessageFormatType.XML:
                    formatter = new XmlMessageFormatter();
                    break;
                case MessageFormatType.Binary:
                    formatter = new BinaryMessageFormatter();
                    break;
                default:
                    throw new NotSupportedException(String.Format("Message format type {0} is not supported.", formatType));
            }

            return formatter;
        }

        public static bool IsAcceptedAtEndpoint(this IMessage message) {
            return message.To.AcceptedMessageTypes.Contains(message.GetType());
        }
    }
}
