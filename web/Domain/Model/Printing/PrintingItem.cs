using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;
using Footprint.Domain.Model.Membership;

namespace Footprint.Domain.Model.Printing
{    
    public class PrintingItem
    {
        [Key]
        public Guid Id { get; set; }
        public UserProfile UserProfile { get; set; }
        public DateTime TimeStamp { get; set; }
        public int PagesPrinted { get; set; } 
    }
}