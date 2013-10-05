using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace Broadcaster.ServiceHeartbeat.Messaging.Metadata {
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Interface,
        AllowMultiple = false,
        Inherited = true)]
    public class TimeToBeReceivedAttribute : Attribute {

        const string NO_TIME_LIMIT = "00:00:00";

        public TimeToBeReceivedAttribute()
            : this(NO_TIME_LIMIT) {
        }

        public TimeToBeReceivedAttribute(string timeSpan) {
            try {
                if (timeSpan == NO_TIME_LIMIT) {
                    Value = Message.InfiniteTimeout;
                }
                else {
                    Value = TimeSpan.Parse(timeSpan);
                }
            }
            catch (FormatException) {
                Value = Message.InfiniteTimeout;
            }
        }

        public TimeSpan Value { get; private set; }

    }
}
