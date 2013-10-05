using System;
using NServiceBus;

namespace Broadcaster.HealthMonitoring {
    [TimeToBeReceived("00:01:00")]
    [Recoverable]
    public interface IHeartbeat : IMessage 
    {
        string ServiceName { get; set; }
        DateTime HeartbeatTime { get; set; }
        TimeSpan ServiceUptime { get; set; }
        TimeSpan HeartbeatFrequency { get; set; }
    }
}
