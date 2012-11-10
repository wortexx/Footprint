namespace Footprint.Printing.Framework
{
    public interface IMainWindow : IShell
    {
        string UserName { get; set; }

        void ShowLogin();
        void ShowPrinting();
    }
}