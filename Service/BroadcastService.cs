using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace Broadcaster.Service
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, InstanceContextMode=InstanceContextMode.Single)]
    public partial class BroadcastService : IBroadcastService
    {
        List<ServiceClient> clients;

        #region IBroadcastService Members

        public event EventHandler<ServiceNotificationEventArgs> ClientConnectionNotification;

        public void Notify(Guid guid, string message)
        {
            ServiceClient announcer = clients.FirstOrDefault((cl) => cl.ClientId == guid);
            if (announcer != null) {

                string msg = String.Format("New message received from client [{0}].", announcer.ClientId);
                this.OnClientConnectionNotification(msg);

                if (clients != null && clients.Count > 0) {
                    ServiceClientComparer comparer = new ServiceClientComparer();
                    foreach (var client in clients) {

                        if (comparer.Equals(client, announcer)) {
                            continue;
                        }

                        try {
                            IBroadcastCallback callback = client.Callback;
                            callback.ReceiveMessage(message);
                            msg = String.Format("New message sent to client [{0}].", client.ClientId);
                            this.OnClientConnectionNotification(msg);
                        }
                        catch {
                        }
                    }
                }
            }
        }

        public Guid Subscribe()
        {
            if (clients == null) {
                clients = new List<ServiceClient>();
            }

            ServiceClient client = ServiceClient.NewClient(Guid.NewGuid());
            client.ClientDisconnected += new EventHandler(client_ClientDisconnected);
            clients.Add(client);

            string message = String.Format("New client subscribed [{0}, Session: {1}].", client.ClientId, client.SessionId);
            this.OnClientConnectionNotification(message);

            return client.ClientId;
        }

        void client_ClientDisconnected(object sender, EventArgs e)
        {
            ServiceClient client = sender as ServiceClient;
            RemoveClientFromSubscriberList(client);
        }

        public void Unsubscribe(Guid guid)
        {
            if (clients != null) {
                ServiceClient client = clients.FirstOrDefault((cl) => cl.ClientId == guid);
                RemoveClientFromSubscriberList(client);
            }
        }

        private void RemoveClientFromSubscriberList(ServiceClient client)
        {
            if (client != null && clients.Contains(client)) {
                clients.Remove(client);
                string message = String.Format("Client [{0}] removed from subscriber list.", client.ClientId);
                this.OnClientConnectionNotification(message);
            }
        }

        #endregion

        protected virtual void OnClientConnectionNotification(string message)
        {
            var handler = this.ClientConnectionNotification;
            if (handler != null) {
                handler(this, new ServiceNotificationEventArgs { Message = message });
            }
        }
    }
}
