using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Broadcaster.Service
{
    partial class BroadcastService
    {
        class ServiceClient
        {
            public IBroadcastCallback Callback { get; set; }
            public Guid ClientId { get; set; }
            public string SessionId { get; set; }

            public event EventHandler ClientDisconnected;

            private ServiceClient()
            {
            }

            public static ServiceClient NewClient(Guid clientId)
            {
                var client = new ServiceClient
                {
                    Callback = OperationContext.Current.GetCallbackChannel<IBroadcastCallback>(),
                    ClientId = clientId,
                    SessionId = OperationContext.Current.SessionId
                };

                var communicationObject = (ICommunicationObject)client.Callback;
                communicationObject.Closed += new EventHandler(client.OnClientDisconnected);

                return client;
            }

            protected virtual void OnClientDisconnected(object sender, EventArgs e)
            {
                var handler = this.ClientDisconnected;
                if (handler != null) {
                    handler(this, EventArgs.Empty);
                }
            }
        }
    }
}
