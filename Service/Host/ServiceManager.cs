using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Windows.Forms;
using xpressive.Wcf.Extensions.ServiceHeartbeat;

namespace Broadcaster.Service.Host
{
    public partial class ServiceManager : Form
    {
        ServiceHost _serviceHost;
        private DateTime _serviceStartTime;
        private string _serviceName;

        public ServiceManager()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.ManageServiceState(this.btnStart, this.btnStop, this.StartService);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.RequestServiceTermination();
        }

        void RequestServiceTermination()
        {
            this.ManageServiceState(this.btnStop, this.btnStart, this.StopService);
        }

        void ManageServiceState(Button activeButton, Button inactiveButton, Action onClickAction)
        {
            var task = new Action(() =>
                                      {
                                          try
                                          {
                                              activeButton.Enabled = false;
                                              activeButton.FlatStyle = FlatStyle.Flat;

                                              inactiveButton.Enabled = true;
                                              inactiveButton.FlatStyle = FlatStyle.Popup;

                                              onClickAction();
                                          }
                                          catch(Exception ex)
                                          {
                                              WriteOutput(ex.Message);

                                              inactiveButton.Enabled = false;
                                              inactiveButton.FlatStyle = FlatStyle.Flat;

                                              activeButton.Enabled = true;
                                              activeButton.FlatStyle = FlatStyle.Popup;
                                          }
                                      });

            if (InvokeRequired)
                Invoke(task);
            else
                task();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void StartService()
        {
            if (_serviceHost == null) {
                InitializeServiceHost();
            }

            _serviceHost.BeginOpen((ar) =>
            {
                try{
                    _serviceHost.EndOpen(ar);
                    _serviceName = _serviceHost.Description.Name;
                    _serviceStartTime = DateTime.Now;
                }
                catch{
                    _serviceHost = null;
                }
            }, null);
        }

        private void InitializeServiceHost()
        {
            BroadcastService serviceInstance = new BroadcastService();
            _serviceHost = new ServiceHost(serviceInstance);
            serviceInstance.ClientConnectionNotification += new EventHandler<ServiceNotificationEventArgs>(OnClientConnectionNotification);

            _serviceHost.Opening += OnServiceHostOpening;
            _serviceHost.Opened += OnServiceHostOpened;
            _serviceHost.Faulted += OnServiceHostFaulted;
            _serviceHost.Closing += OnServiceHostClosing;
            _serviceHost.Closed += OnServiceHostClosed;

        }

        void StopService()
        {
            if (_serviceHost != null) {
                _serviceHost.BeginClose((ar) =>
                {
                    try{
                        _serviceHost.EndClose(ar);
                    }
                    finally {
                        _serviceHost = null;
                    }
                }, null);
            }
        }
        void OnClientConnectionNotification(object sender, ServiceNotificationEventArgs e)
        {
            WriteOutput(e.Message);
        }

        void OnServiceHostClosed(object sender, EventArgs e)
        {
            WriteOutput("Broadcast service stopped.");
        }

        void OnServiceHostClosing(object sender, EventArgs e)
        {
            WriteOutput("Stopping Broadcast service...");
        }

        void OnServiceHostFaulted(object sender, EventArgs e)
        {
            WriteOutput("A fault occurred on the Broadcast service...");
            this.RequestServiceTermination();
        }

        void OnServiceHostOpened(object sender, EventArgs e)
        {
            WriteOutput("Broadcast service started.");
        }

        void OnServiceHostOpening(object sender, EventArgs e)
        {
            WriteOutput("Starting Broadcast service...");
        }

        void WriteOutput(string message)
        {
            Action write = () =>
            {
                string line = String.Format("{0}\r\n", message);
                txtOutput.Text += line;
                txtOutput.Select(txtOutput.Text.Length, 0);
                txtOutput.ScrollToCaret();
            };

            if (this.InvokeRequired) {
                this.Invoke(write);
            }
            else {
                write();
            }
        }

        private void ServiceManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopService();
        }
    }
}
