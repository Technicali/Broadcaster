using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.Service
{
    public class ServiceNotificationEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
