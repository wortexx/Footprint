using System;
using System.Configuration;
using System.Management;

namespace Footprint.Printing.Services.Printing
{
    public delegate void PagesPrinted(int pages);

    public class PrintingMonitor : IPrintingMonitor
    {
        private readonly IPrintingNotifyService _printingNotifyService;

        private const string WmiQuery = "Select * From __InstanceCreationEvent Within 1 " +
                                        "Where TargetInstance ISA 'Win32_PrintJob' ";

        private ManagementEventWatcher _watcher;

        public event PagesPrinted Printed;

        public PrintingMonitor(IPrintingNotifyService printingNotifyService)
        {            
            _printingNotifyService = printingNotifyService;
        }

        protected string ComputerName
        {
            get { return ConfigurationManager.AppSettings["ComputerName"]; }
        }

        public void Start(PagesPrinted callback)
        {
            Printed += callback;

            try
            {                
                
                ManagementScope scope;

                if (!ComputerName.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                {
                    var conn = new ConnectionOptions();
                    conn.Username = "";
                    conn.Password = "";
                    conn.Authority = "ntlmdomain:DOMAIN";
                    scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), conn);
                }
                else
                {
                    scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", ComputerName), null);
                }
                scope.Connect();

                _watcher = new ManagementEventWatcher(scope, new EventQuery(WmiQuery));
                _watcher.EventArrived += new EventArrivedEventHandler(this.WmiEventHandler);
                _watcher.Start();
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0} Trace {1}", e.Message, e.StackTrace);
            }

        }

        private void WmiEventHandler(object sender, EventArrivedEventArgs e)
        {
            var mgmt = ((ManagementBaseObject)e.NewEvent.Properties["TargetInstance"].Value);
            if (mgmt == null)
            {
                return;
            }
            var status = mgmt["JobStatus"];

            var statusMask = Convert.ToInt32(mgmt["StatusMask"]);

            var pagesPrinted2 = Convert.ToInt32(mgmt["PagesPrinted"]);
            var pagesPrinted = Convert.ToInt32(mgmt["TotalPages"]);

            if (pagesPrinted > 0)
            {
                this.OnPrinted(pagesPrinted);
            }
            
        }

        public void Stop()
        {
            _watcher.Stop();
        }

        private void OnPrinted(int pages)
        {
            if (this.Printed != null)
            {
                _printingNotifyService.OnPrinted(pages);
                this.Printed(pages);
            }
        }
    }
}