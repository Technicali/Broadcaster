﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Broadcaster.ServiceHeartbeat.Messaging {
    [Serializable]
    public enum SubscriptionMessageType {
        Subscribe,
        Unsubscribe,
        SubscribeConfirmation,
        UnsubscribeConfirmation
    }
}
