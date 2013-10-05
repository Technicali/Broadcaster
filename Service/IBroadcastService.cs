using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Broadcaster.Service
{
    [ServiceContract(
        CallbackContract = typeof(IBroadcastCallback),
        Namespace = "http://www.xpressive.com/broadcaster/2009/10",
        SessionMode = SessionMode.Required)]
    public interface IBroadcastService
    {
        [OperationContract]
        Guid Subscribe();

        [OperationContract(IsOneWay = true)]
        void Unsubscribe(Guid guid);

        [OperationContract(IsOneWay = true)]
        void Notify(Guid guid, string message);

        event EventHandler<ServiceNotificationEventArgs> ClientConnectionNotification;
    }
}
