using System.Collections.Generic;
using System.Linq;

namespace Footprint.Site.Models
{
    public class Consumer
    {
        public  Consumer()
        {
            Statistic = new List<StatisticItemModel>();
        }

        public IList<StatisticItemModel> Statistic { get; set; }
        public decimal Total
        {
            get { return Statistic.Sum(x => x.Usage); }
        }
    }
}