namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "ReservationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "ReservationId", c => c.Int(nullable: false));
        }
    }
}
