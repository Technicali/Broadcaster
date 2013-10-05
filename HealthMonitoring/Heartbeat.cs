using System;

namespace Broadcaster.HealthMonitoring {

    [Serializable]
    public class Heartbeat : IHeartbeat {

        #region IHeartbeat Members

        public string ServiceName { get; set; }
        public DateTime HeartbeatTime { get; set; }
        public TimeSpan ServiceUptime { get; set; }
        public TimeSpan HeartbeatFrequency { get; set; }

        #endregion
    }

}
