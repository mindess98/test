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
        /*public HotelContext() : base()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }*/
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                        .HasRequired(g => g.Reservation)
                        .WithMany(r => r.Guests)
                        .HasForeignKey(g => g.ReservationId);

            modelBuilder.Entity<Room>()
                        .HasOptional(ro => ro.Reservation)
                        .WithRequired(re => re.Room);

            modelBuilder.Entity<Room>()
                        .HasRequired(ro => ro.RoomType)
                        .WithMany(rt => rt.Rooms)
                        .HasForeignKey(ro => ro.RoomTypeId);
                        
            base.OnModelCreating(modelBuilder);
        }
    }

    /*public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            RoomType rt1 = new RoomType { Name = "Deluxe", StarValue = 5 };
            RoomType rt2 = new RoomType { Name = "Economy", StarValue = 3 };
            RoomType rt3 = new RoomType { Name = "Elegant", StarValue = 4 };

            context.RoomTypes.Add(rt1);
            context.RoomTypes.Add(rt2);
            context.RoomTypes.Add(rt3);
                    new Room { Price = 100, RoomType = rt2, Capacity = 3 },
                    new Room { Price = 120, RoomType = rt2, Capacity = 4 },
                    new Room { Price = 130, RoomType = rt2, Capacity = 5 },
                    new Room { Price = 250, RoomType = rt3, Capacity = 2 },
                    new Room { Price = 350, RoomType = rt3, Capacity = 4 },
                    new Room { Price = 900, RoomType = rt1, Capacity = 4 },
                    new Room { Price = 1200, RoomType = rt1, Capacity = 6 }

            context.Rooms.Add(r1);
            context.Rooms.Add(r2);
            context.Rooms.Add(r3);
            context.Rooms.Add(r4);
            context.Rooms.Add(r5);
            context.Rooms.Add(r6);
            context.Rooms.Add(r7);


            base.Seed(context);
        }
    }*/
}
