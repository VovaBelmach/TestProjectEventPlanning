namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateOfEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Date");
        }
    }
}
