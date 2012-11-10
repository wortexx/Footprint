using System.Data.Entity;
using Footprint.Domain.Model.Membership;
using Footprint.Domain.Model.Tracking;

namespace Footprint.Domain.Model
{
    public class FootprintContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LocationTrack> LocationTracks { get; set; }
    }
}