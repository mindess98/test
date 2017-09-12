namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "RoomImage");
        }
    }
}
