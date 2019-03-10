namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserEvents", name: "Id_Event", newName: "EventId");
            RenameColumn(table: "dbo.UserEvents", name: "Id_Users", newName: "UserId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Id_Users", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Id_Event", newName: "IX_EventId");
            AddColumn("dbo.Events", "Name", c => c.String());
            AddColumn("dbo.Events", "Theme", c => c.String());
            AddColumn("dbo.Events", "Location", c => c.String());
            AddColumn("dbo.Events", "Description", c => c.String());
            DropColumn("dbo.Events", "EventName");
            DropColumn("dbo.Events", "EventTheme");
            DropColumn("dbo.Events", "EventLocation");
            DropColumn("dbo.Events", "EventDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventDescription", c => c.String());
            AddColumn("dbo.Events", "EventLocation", c => c.String());
            AddColumn("dbo.Events", "EventTheme", c => c.String());
            AddColumn("dbo.Events", "EventName", c => c.String());
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Location");
            DropColumn("dbo.Events", "Theme");
            DropColumn("dbo.Events", "Name");
            RenameIndex(table: "dbo.UserEvents", name: "IX_EventId", newName: "IX_Id_Event");
            RenameIndex(table: "dbo.UserEvents", name: "IX_UserId", newName: "IX_Id_Users");
            RenameColumn(table: "dbo.UserEvents", name: "UserId", newName: "Id_Users");
            RenameColumn(table: "dbo.UserEvents", name: "EventId", newName: "Id_Event");
        }
    }
}
