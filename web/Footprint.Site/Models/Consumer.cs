using System.Collections.Generic;

namespace Footprint.Site.Models
{
    public class Consumer
    {
        public  Consumer()
        {
            Statistic = new List<StatisticItemModel>();
        }

        public IList<StatisticItemModel> Statistic { get; set; }
    }
}