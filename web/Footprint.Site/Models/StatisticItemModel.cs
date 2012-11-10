using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Footprint.Models
{
    public class StatisticItemModel
    {
        public string Consumer { get; set; }
        public decimal Usage { set; get; }
        public decimal Norm { set; get; }
        public bool IsEffective { get { return Usage <= Norm; }
        }
    
    }
}