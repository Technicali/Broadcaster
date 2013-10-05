using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat.Messaging {
    [Serializable]
    public class BaseMessage :IMessage {
        #region IMessage Members

        public IEndpoint From { get; set; }
        public IEndpoint To { get; set; }
        public string Subject { get; set; }

        #endregion
    }
}
