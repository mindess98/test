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
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                        .HasRequired(g => g.Reservation)
                        .WithMany(r => r.Guests)
                        .HasForeignKey(g => g.ReservationId);

            modelBuilder.Entity<Room>()
                        .HasOptional(ro => ro.Reservation)
                        .WithRequired(re => re.Room);
            
                        
            base.OnModelCreating(modelBuilder);
        }
    }
}
