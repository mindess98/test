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

        protected override void Seed(test.HotelContext context)
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
            RoomType rt2 = new RoomType { Name = "Elegant", StarValue = 4 };
            RoomType rt3 = new RoomType { Name = "Economy", StarValue = 3 };

            context.RoomTypes.AddOrUpdate(x => x.Name, rt1, rt2, rt3);
        }
    }
}
