namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTimeOfEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Time");
        }
    }
}
