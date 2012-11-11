namespace Footprint.Site.Models
{
    public class StatisticItemModel
    {
        public string Consumer { get; set; }
        public decimal TotalUsage { set; get; }
        public decimal Norm { set; get; }
        public decimal Usage
        {
            get { return TotalUsage/Days; }
        }
        public int Days { get; set; }
        public bool IsEffective { get { return Usage <= Norm; }}
    }
}