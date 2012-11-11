using System;
using System.ComponentModel.DataAnnotations;
using Footprint.Domain.Model.Membership;

namespace Footprint.Domain.Model.Statistics
{
    public class StatisticsItem
    {
        [Key]
        public Guid Id { get; set; }
        public UserProfile UserProfile { get; set; }
        public DateTime Day { get; set; }
        public string Consumer { get; set; }
        public decimal Value { get; set; }
    }
}