using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Spatial;
using Footprint.Domain.Model.Membership;

namespace Footprint.Domain.Model.Tracking
{
    public class LocationTrack
    {
        [Key]
        public Guid Id { get; set; }
        public UserProfile UserProfile { get; set; }
        public DateTime TimeStamp { get; set; }
        public DbGeography Location { get; set; }
        public double Speed { get; set; }
    }
}