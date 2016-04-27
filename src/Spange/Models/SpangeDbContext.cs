using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spange.Models
{
    public class SpangeDbContext : DbContext
    {
        public DbSet<Camp> Camps { get; set; }
        public DbSet<ClaimSpot> ClaimSpots { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<PitchCamp> PitchCamps { get; set; }
        public DbSet<PlayerFood> PlayerFoods { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Spot> Spots { get; set; }
    }
}