using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Footprint.Printing.Framework;
using Footprint.Printing.Services;
using Footprint.Printing.Services.Auth;
using Footprint.Printing.Services.Printing;

namespace Footprint.Printing.ViewModels
{
    public class ShellViewModel : Conductor<IShell>.Collection.OneActive, IMainWindow
    {

        private readonly IAuthService _authService; 
        private readonly IPrintingMonitor _printingMonitor;

        public ShellViewModel(IAuthService authService, IPrintingMonitor printingMonitor)
        {
            _authService = authService;
            _printingMonitor = printingMonitor;
            this.
            ShowLogin();
        }

        public string UserName { get; set; }

        public void ShowLogin()
        {
            this.DisplayName = "Enter your login and password";
            ActivateItem(new LoginViewModel(_authService));
        }

        public void ShowPrinting()
        {
            this.DisplayName = "Printing paper calculation...";
            ActivateItem(new PrintingViewModel(this.UserName, _printingMonitor));
        }
    }
}
