using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat.Messaging.Metadata {
    class MessageAttributes {

        private MessageAttributes() {
        }

        public PriorityAttribute Priority { get; private set; }
        public TimeToBeReceivedAttribute TimeToBeReceived { get; private set; }
        public MessageFormatAttribute MessageFormat { get; private set; }

        public static MessageAttributes GetMessageAttributes(IMessage message) {

            MessageAttributes messageAttributes = new MessageAttributes();

            Attribute[] attributes = Attribute.GetCustomAttributes(message.GetType());
            foreach (var attribute in attributes) {

                if (messageAttributes.Priority == null) {
                    messageAttributes.Priority = attribute as PriorityAttribute;
                    if (messageAttributes.Priority != null) {
                        continue;
                    }
                }

                if (messageAttributes.TimeToBeReceived == null) {
                    messageAttributes.TimeToBeReceived = attribute as TimeToBeReceivedAttribute;
                    if (messageAttributes.TimeToBeReceived != null) {
                        continue;
                    }
                }

                if (messageAttributes.MessageFormat == null) {
                    messageAttributes.MessageFormat = attribute as MessageFormatAttribute;
                    if (messageAttributes.MessageFormat != null) {
                        continue;
                    }
                }
            }

            if (messageAttributes.Priority == null) {
                messageAttributes.Priority = new PriorityAttribute();
            }

            if (messageAttributes.TimeToBeReceived == null) {
                messageAttributes.TimeToBeReceived = new TimeToBeReceivedAttribute();
            }

            if (messageAttributes.MessageFormat == null) {
                messageAttributes.MessageFormat = new MessageFormatAttribute();
            }

            return messageAttributes;
        }
    }
}
