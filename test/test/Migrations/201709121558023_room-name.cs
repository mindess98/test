namespace test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roomname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Name");
        }
    }
}
