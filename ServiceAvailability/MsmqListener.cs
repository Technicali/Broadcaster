using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;

namespace Broadcaster.ServiceHeartbeat {
    class MsmqListener<TMessage> : IListener<TMessage> where TMessage : IMessage {

        private IEndpoint _ownerEndpoint;
        private MessageFormatType _expectedFormat;

        public MsmqListener(IEndpoint ownerEndpoint, MessageFormatType expectedMessageFormat) {
            if (ownerEndpoint == null) {
                throw new ArgumentNullException("ownerEndpoint");
            }

            _ownerEndpoint = ownerEndpoint;
            _expectedFormat = expectedMessageFormat;
        }

        #region IListener<TMessage> Members

        public TMessage Receive() {
            return Receive(Message.InfiniteTimeout);
        }

        public TMessage Receive(TimeSpan timeout) {
            var messageQueue = MsmqChannelHelper.GetMessageQueue(_ownerEndpoint.Address);
            return MsmqChannelHelper.Receive<TMessage>(messageQueue, _expectedFormat, timeout);
        }

        #endregion
    }
}
