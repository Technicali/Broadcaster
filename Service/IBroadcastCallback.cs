using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Broadcaster.Service
{
    public interface IBroadcastCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(string message);
    }
}
