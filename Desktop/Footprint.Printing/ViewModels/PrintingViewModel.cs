using Caliburn.Micro;
using Footprint.Printing.Framework;
using Footprint.Printing.Services.Printing;

namespace Footprint.Printing.ViewModels
{
    public class PrintingViewModel : Screen, IShell
    {
        private readonly IPrintingMonitor _printingMonitor;
        private string _userName;
        private int _pagesPrinted;
        
        public PrintingViewModel(string userName, IPrintingMonitor printingMonitor)
        {
            _printingMonitor = printingMonitor;
            this.UserName = userName;
            printingMonitor.Start(OnPagesPrinted);
        }

        public int PagesPrinted
        {
            get { return _pagesPrinted; }
            set
            {
                _pagesPrinted = value;
                NotifyOfPropertyChange(() => this.PagesPrinted);
            }
        }
        
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => this.UserName);
            }
        }

        private void OnPagesPrinted(int pages)
        {
            this.PagesPrinted += pages;
        }
    }
}