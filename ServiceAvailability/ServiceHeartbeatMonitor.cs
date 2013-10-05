using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging;
using Broadcaster.ServiceHeartbeat.Messaging.Metadata;

namespace Broadcaster.ServiceHeartbeat {

    public class ServiceHeartbeatMonitor : IDisposable
    {
        readonly IEndpoint _publisherEndpoint;
        readonly IEndpoint _subscriberEndpoint;
        readonly Guid _subscriptionToken;

        readonly IChannel<SubscriptionMessage> _subscriptionChannel;
        readonly IChannel<ServiceHeartbeatMessage> _heartbeatChannel;


        public ServiceHeartbeatMonitor(IEndpoint publisherEndpoint, IEndpoint subscriberEndpoint) {
        }

        public ServiceHeartbeatMonitor(IEndpoint publisherEndpoint, IEndpoint subscriberEndpoint, MessageFormatType expectedMessageFormat)
            : this(publisherEndpoint, 
                    subscriberEndpoint, 
                    new SubscriptionsMsmqChannel(subscriberEndpoint, expectedMessageFormat), 
                    new ServiceHeartbeatMsmqChannel(subscriberEndpoint, expectedMessageFormat))
        {
        }

        public ServiceHeartbeatMonitor(IEndpoint publisherEndpoint, IEndpoint subscriberEndpoint, IChannel<SubscriptionMessage> subscriptionChannel, IChannel<ServiceHeartbeatMessage> heartbeatChannel) {
            
            if (publisherEndpoint == null) {
                throw new ArgumentNullException("publisherEndpoint");
            }

            if (subscriberEndpoint == null) {
                throw new ArgumentNullException("subscriberEndpoint");
            }

            if (subscriptionChannel == null) {
                throw new ArgumentNullException("subscriptionChannel");
            }

            if (heartbeatChannel == null) {
                throw new ArgumentNullException("heartbeatChannel");
            }

            _publisherEndpoint = publisherEndpoint;
            _subscriberEndpoint = subscriberEndpoint;
            _subscriptionChannel = subscriptionChannel;
            _heartbeatChannel = heartbeatChannel;
            _subscriptionToken = Guid.NewGuid();
        }
        
        public Guid StartMonitoring() {

            // send subscription request
            var subcribe = new SubscriptionMessage {
                From = _subscriberEndpoint,
                To = _publisherEndpoint,
                RequestType = SubscriptionMessageType.Subscribe,
                Subject = "Please include in heartbeat notifications"
            };

            _subscriptionChannel.Dispatcher.Send(subcribe);



            return _subscriptionToken;
        }

        public void StopMonitoring(Guid subscriptionToken) {
            if (subscriptionToken.CompareTo(_subscriptionToken) != 0) {
                throw new InvalidOperationException("Invalid subscription token. Cannot stop monitoring.");
            }

        }

        #region IDisposable Members

        public void Dispose() {
            throw new NotImplementedException();
        }

        #endregion
    }
}
