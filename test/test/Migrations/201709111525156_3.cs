namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "ReservationId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "ReservationId");
        }
    }
}
