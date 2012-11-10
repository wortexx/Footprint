﻿using System.Data.Entity;
using Footprint.Domain.Model.Membership;
using Footprint.Domain.Model.Printing;
using Footprint.Domain.Model.Tracking;

namespace Footprint.Domain.Model
{
    public class FootprintContext : DbContext
    {
        public FootprintContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LocationTrack> LocationTracks { get; set; }
        public DbSet<PrintingItem> PrintingItems { get; set; }
    }
}