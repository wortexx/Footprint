using System.Data.Entity;
using Footprint.Domain.Model.Membership;
using Footprint.Domain.Model.Printing;
using Footprint.Domain.Model.Statistics;
using Footprint.Domain.Model.Tracking;

namespace Footprint.Domain.Model
{
    public class FootprintContext : DbContext
    {
        public FootprintContext()
            : base("DefaultConnection")
        {
            
        }

        public DbSet<LocationTrack> LocationTracks { get; set; }
        public DbSet<PrintingItem> PrintingItems { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; } 
        public DbSet<StatisticsItem> Statistics { get; set; }
    }
}