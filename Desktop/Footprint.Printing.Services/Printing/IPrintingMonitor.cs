using System;

namespace Footprint.Printing.Services.Printing
{
    public interface IPrintingMonitor
    {       
        void Start(PagesPrinted callback);
        void Stop();
    }
}