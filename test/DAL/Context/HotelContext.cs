using test.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                        .HasRequired(r => r.Guest)
                        .WithOptional(g => g.Reservation);
                        

            modelBuilder.Entity<Room>()
                        .HasMany(ro => ro.Reservations)
                        .WithMany(re => re.Rooms);

            modelBuilder.Entity<Room>()
                        .HasRequired(ro => ro.Type)
                        .WithMany(rt => rt.Rooms)
                        .HasForeignKey(ro => ro.RoomTypeId);
                        
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
