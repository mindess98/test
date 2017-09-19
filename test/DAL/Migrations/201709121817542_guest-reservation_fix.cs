namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guestreservation_fix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        GuestId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guests", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Capacity = c.Int(nullable: false),
                        ReservationId = c.Int(),
                        RoomTypeId = c.Int(nullable: false),
                        RoomImage = c.Binary(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reservations", t => t.ReservationId)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.ReservationId)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StarValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "Id", "dbo.Guests");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Rooms", new[] { "ReservationId" });
            DropIndex("dbo.Reservations", new[] { "Id" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Reservations");
            DropTable("dbo.Guests");
        }
    }
}
