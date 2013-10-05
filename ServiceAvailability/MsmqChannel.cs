using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;

namespace Broadcaster.ServiceHeartbeat {

    abstract class MsmqChannel<TMessage> : IChannel<TMessage> where TMessage : IMessage {

        private IListener<TMessage> _listener;
        private IDispatcher<TMessage> _dispatcher;

        public MsmqChannel(IEndpoint ownerEndpoint, MessageFormatType expectedMessageFormat) {
            
            if (ownerEndpoint == null) {
                throw new ArgumentNullException("ownerEndpoint");
            }

            _dispatcher = new MsmqDispatcher<TMessage>();
            _listener = new MsmqListener<TMessage>(ownerEndpoint, expectedMessageFormat);
        }

        #region IChannel<TMessage> Members

        public IDispatcher<TMessage> Dispatcher {
            get { return _dispatcher; }
        }

        public IListener<TMessage> Listener {
            get { return _listener; }
        }

        #endregion
    }
}
