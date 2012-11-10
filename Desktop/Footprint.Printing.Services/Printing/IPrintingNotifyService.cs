namespace Footprint.Printing.Services.Printing
{
    public interface IPrintingNotifyService
    {
        void OnPrinted(int pagesPrinted);
    }
}