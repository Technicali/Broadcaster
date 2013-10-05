using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using Broadcaster.ServiceHeartbeat.Extensions;
using Broadcaster.ServiceHeartbeat.Messaging;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;

namespace Broadcaster.ServiceHeartbeat {
    abstract class MsmqChannelHelper {

        public static MessageQueue GetMessageQueue(string path) {
            MessageQueue mq;
            if (MessageQueue.Exists(path)) {
                mq = new MessageQueue(path);
            }
            else {
                mq = CreateMessageQueue(path);
            }
            return mq;
        }

        public static TMessage Receive<TMessage>(MessageQueue messageQueue, MessageFormatType expectedFormat)
            where TMessage : IMessage {
            return Receive<TMessage>(messageQueue, expectedFormat, Message.InfiniteTimeout);
        }

        public static TMessage Receive<TMessage>(MessageQueue messageQueue, MessageFormatType expectedFormat, TimeSpan timeout)
            where TMessage : IMessage {
            Message message = messageQueue.Receive(timeout);
            IMessageFormatter formatter = expectedFormat.GetMessageFormatter();
            TMessage body = (TMessage)formatter.Read(message);
            return body;
        }

        public static bool Send<TMessage>(TMessage message, MessageQueue messageQueue)
            where TMessage : IMessage {
            bool success = false;

            if (message.IsAcceptedAtEndpoint()) {
                try {
                    Message msg = CreateConfiguredMessage(message);
                    messageQueue.Send(msg, message.Subject);
                    success = true;
                }
                catch {
                    success = false;
                }
            }

            return success;
        }

        private static MessageQueue CreateMessageQueue(string path) {
            return MessageQueue.Create(path);
        }

        private static Message CreateConfiguredMessage(IMessage body) {

            Message message = new Message();

            MessageAttributes attributes = MessageAttributes.GetMessageAttributes(body);
            message.Priority = attributes.Priority.Value;
            message.TimeToBeReceived = attributes.TimeToBeReceived.Value;

            IMessageFormatter formatter = attributes.MessageFormat.Value.GetMessageFormatter();
            formatter.Write(message, body);

            return message;
        }
    }
}
