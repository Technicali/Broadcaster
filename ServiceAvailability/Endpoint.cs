using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using Broadcaster.ServiceHeartbeat.Messaging;

namespace Broadcaster.ServiceHeartbeat {
    internal class Endpoint : IEndpoint {

        readonly string _ownerName;
        readonly string _path;
        private List<Type> _acceptedMessageTypes;

        public Endpoint(string ownerName, string path) {

            if (String.IsNullOrEmpty(ownerName)) {
                throw new ArgumentException("The owner name must be specified", "ownerName");
            }

            if (String.IsNullOrEmpty(path)) {
                throw new ArgumentException("The message queue path must be specified", "path");
            }

            _ownerName = ownerName;
            _path = path;
            _acceptedMessageTypes = new List<Type>();
        }

        public Endpoint(string ownerName, string path, params Type[] acceptedMessageTypes)
            : this(ownerName, path) {
            foreach (var messageType in acceptedMessageTypes) {
                AddAcceptedMessageType(messageType);
            }
        }

        public void AddAcceptedMessageType(Type messageType) {
            if (messageType == null) {
                throw new ArgumentNullException("messageType");
            }

            if (!typeof(IMessage).IsAssignableFrom(messageType)) {
                throw new ArgumentException("The specified message type does not inherit from IServiceHeartbeatMessage", "messageType");
            }

            if (!_acceptedMessageTypes.Contains(messageType)) {
                _acceptedMessageTypes.Add(messageType);
            }
        }

        #region IEndpoint Members

        public string OwnerName { get { return _ownerName; } }

        public string Address {
            get { return _path; }
        }

        public IEnumerable<Type> AcceptedMessageTypes {
            get { return _acceptedMessageTypes; }
        }

        #endregion
    }
}
