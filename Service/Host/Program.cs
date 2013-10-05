using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Broadcaster.Service.Host
{
    class Program
    {
        const string SINGLE_INSTANCE_MUTEX_NAME = "BroadcastService.Host.Form";

        [STAThread]
        static void Main()
        {
            bool instanceCreated = false;
            using (Mutex singleInstanceMutex = new Mutex(true, SINGLE_INSTANCE_MUTEX_NAME, out instanceCreated)) {
                if (instanceCreated) {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ServiceManager());
                    singleInstanceMutex.ReleaseMutex();
                }
                else {
                    MessageBox.Show("The Broadcast Service Manager is already running", "Broadcast Service Manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
