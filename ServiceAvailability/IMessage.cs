using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat {
    public interface IMessage {
        IEndpoint From { get; set; }
        IEndpoint To { get; set; }
        string Subject { get; set; }
    }
}
