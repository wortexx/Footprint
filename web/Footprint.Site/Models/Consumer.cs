using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footprint.Models
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