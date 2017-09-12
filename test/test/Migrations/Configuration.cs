namespace test.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<test.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            RoomType rt1 = new RoomType { Name = "Deluxe", StarValue = 5 };
            RoomType rt2 = new RoomType { Name = "Economy", StarValue = 3 };
            RoomType rt3 = new RoomType { Name = "Elegant", StarValue = 4 };

            context.RoomTypes.AddOrUpdate(x => x.Name,
                rt1,
                rt2,
                rt3
                );

            context.Rooms.AddOrUpdate(x => x.Id,
                new Room { Price = 100, RoomType = rt2, Capacity = 3 , Name = "Twin+ Guest Room"},
                new Room { Price = 120, RoomType = rt2, Capacity = 4 , Name = "Family Guest Room"},
                new Room { Price = 130, RoomType = rt2, Capacity = 5 , Name = "Large Family Room"},
                new Room { Price = 250, RoomType = rt3, Capacity = 2 , Name = "King Guest Room"},
                new Room { Price = 350, RoomType = rt3, Capacity = 4 , Name = "Two Queen Bed Room"},
                new Room { Price = 900, RoomType = rt1, Capacity = 4 , Name = "Executive Suite"},
                new Room { Price = 1200, RoomType = rt1, Capacity = 6, Name = "Presidential Suite"});
        }
    }
}
