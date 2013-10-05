using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.Service
{
    partial class BroadcastService
    {
        class ServiceClientComparer : IEqualityComparer<ServiceClient>
        {
            #region IEqualityComparer<ServiceClient> Members

            public bool Equals(ServiceClient x, ServiceClient y)
            {
                return x.ClientId == y.ClientId;
            }

            public int GetHashCode(ServiceClient obj)
            {
                return obj.ClientId.GetHashCode();
            }

            #endregion
        }
    }
}
