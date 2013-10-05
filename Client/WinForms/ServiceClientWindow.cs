using System;
using System.ComponentModel;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using xpressive.Wcf.Extensions.ServiceHeartbeat;

namespace Broadcaster.Client.WinForms {
    public partial class ServiceClientWindow : Form, IBroadcastServiceCallback {

        readonly Action<string> _receiveMessageDelegate;
        readonly BindingList<ServiceMessage> _receivedMessages;
        readonly InstanceContext _serviceHost;
        readonly ServiceHeartbeatClient _heartbeatClient;
        readonly BroadcastServiceClient _client;
        Guid _clientId;
        bool _serviceRunning;

        public ServiceClientWindow()
        {
            InitializeComponent();

            _receiveMessageDelegate = this.ReceiveMessage;
            _receivedMessages = new BindingList<ServiceMessage>();
            receivedMessageList.DataSource = _receivedMessages;
            receivedMessageList.DisplayMember = "Text";

            _serviceHost = new InstanceContext(null, this);
            _heartbeatClient = new ServiceHeartbeatClient("net.tcp://127.0.0.1:7007/broadcaster/Service", xpressive.Wcf.Extensions.Channels.TransportMode.Msmq, new TimeSpan(0, 0, 30));
            _heartbeatClient.ServiceStatusChanged += _heartbeatClient_ServiceStatusChanged;

            if (_client == null ||
                _client.State != CommunicationState.Opened)
            {
                _client = new BroadcastServiceClient(_serviceHost);
            }
        }

        void _heartbeatClient_ServiceStatusChanged(object sender, EventArgs e) {
            ServiceRunning = _heartbeatClient.ServiceStatus == ServiceHeartbeatClient.HeartbeatServiceStatus.Running;
        }

        private void btnSend_Click(object sender, EventArgs e) {
            _client.BeginNotify(
                _clientId,
                txtMessage.Text,
                (ar) => {
                    _client.EndNotify(ar);
                    ClearMessageTextBox();
                },
                null);
        }

        void ClearMessageTextBox() {
            Action action = () => txtMessage.Clear();
            if (InvokeRequired) {
                Invoke(action);
            }
            else {
                action();
            }
        }

        #region IBroadcastServiceCallback Members

        public void ReceiveMessage(string message) {
            _receivedMessages.Add(new ServiceMessage { Text = message, TimeReceived = DateTime.Now });
        }

        public IAsyncResult BeginReceiveMessage(string message, AsyncCallback callback, object asyncState) {
            IAsyncResult ar = _receiveMessageDelegate.BeginInvoke(message, callback, asyncState);
            return ar;
        }

        public void EndReceiveMessage(IAsyncResult result) {
            _receiveMessageDelegate.EndInvoke(result);
        }

        #endregion

        private bool ServiceRunning {
            get {
                return _serviceRunning;
            }
            set {
                if (_serviceRunning != value) {
                    _serviceRunning = value;
                    if (!_serviceRunning) {
                        Unsubscribe();
                    }
                    ShowServiceStatus(_serviceRunning);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnSubscribe_Click(object sender, EventArgs e) {
            Subscribe();

            txtMessage.Enabled = true;
            btnSend.Enabled = true;
            btnSubscribe.Enabled = false;
            btnUnsubscribe.Enabled = true;
        }

        private void btnUnsubscribe_Click(object sender, EventArgs e) {
            Unsubscribe();

            txtMessage.Enabled = false;
            btnSend.Enabled = false;
            btnSubscribe.Enabled = true;
            btnUnsubscribe.Enabled = false;
        }

        private void ServiceClientWindow_FormClosing(object sender, FormClosingEventArgs e) {

            _heartbeatClient.ServiceStatusChanged -= _heartbeatClient_ServiceStatusChanged;
            _heartbeatClient.Dispose();

            if (e.CloseReason != CloseReason.TaskManagerClosing) {
                if (ServiceRunning)
                    Unsubscribe();
            }
        }

        private void Unsubscribe() {
            if (_client != null && _client.State == CommunicationState.Opened) {
                _client.Unsubscribe(_clientId);
            }
        }

        private void Subscribe() {
            _clientId = _client.Subscribe();
        }

        void ShowServiceStatus(bool running) {
            Action action = () => {
                string message = String.Format("The Broadcast Service is {0} running...", running ? "up and" : "not");
                Color foreColor = running ? Color.Green : Color.Red;

                lblServiceStatus.Text = message;
                lblServiceStatus.ForeColor = foreColor;
                ConnectionControlState(running);
            };

            if (InvokeRequired) {
                Invoke(action);
            }
            else {
                action();
            }
        }

        void ConnectionControlState(bool running) {
            txtMessage.Enabled = false;
            btnSend.Enabled = false;
            btnSubscribe.Enabled = running;
            btnUnsubscribe.Enabled = false;
        }

        class ServiceMessage {
            public string Text { get; set; }
            public DateTime TimeReceived { get; set; }
        }
    }
}
