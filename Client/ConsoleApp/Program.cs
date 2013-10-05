using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broadcaster.Client;
using System.ServiceModel;

namespace Broadcaster.Client.ConsoleApp
{
    class Program : IBroadcastServiceCallback
    {
        static void Main(string[] args)
        {
            int msgId = 0;
            InstanceContext site = new InstanceContext(null, new Program());
            BroadcastServiceClient client = new BroadcastServiceClient(site);

            Console.WriteLine("Subscribing to Broadcaster Service");
            Guid clientId = client.Subscribe();

            while (true) {
                Console.WriteLine();
                Console.Write("Press p to publish a message, or u to unsubscribe and shut down client: ");
                ConsoleKeyInfo key = Console.ReadKey(false);

                if (key.Key == ConsoleKey.U) {
                    break;
                }

                if (key.Key == ConsoleKey.P) {
                    msgId++;
                    Console.WriteLine("\nYour message will have message ID {0}.", msgId.ToString());
                    Console.WriteLine("Write your message and press ENTER to publish: ");
                    string message = Console.ReadLine();
                    if (!String.IsNullOrEmpty(message)) {
                        client.BeginNotify(
                            clientId,
                            message,
                            (ar) =>
                            {
                                client.EndNotify(ar);
                                int mId = (int)ar.AsyncState;
                                Console.WriteLine("\nMessage {0} sent to service.\n", mId);
                            },
                            msgId);
                    }
                }
            }

            Console.WriteLine("Unsubscribing from Broadcaster Service");
            client.Unsubscribe(clientId);

            client.Close();

        }

        #region IBroadcastServiceCallback Members

        public void ReceiveMessage(string message)
        {
            Console.WriteLine("Update received from service: " + message);
        }

        public IAsyncResult BeginReceiveMessage(string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiveMessage(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
