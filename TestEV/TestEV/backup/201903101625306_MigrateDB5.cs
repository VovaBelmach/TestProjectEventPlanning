namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class MigrateDB5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events");
            RenameColumn(table: "dbo.UserEvents", name: "Id_Users", newName: "UserId");
            RenameColumn(table: "dbo.UserEvents", name: "Id_Event", newName: "EventId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Id_Users", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserEvents", name: "IX_Id_Event", newName: "IX_EventId");
            DropPrimaryKey("dbo.Events");
            DropPrimaryKey("dbo.UserEvents");
            AddColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Events", "Name", c => c.String());
            AddColumn("dbo.Events", "Theme", c => c.String());
            AddColumn("dbo.Events", "Location", c => c.String());
            AddColumn("dbo.Events", "Description", c => c.String());
            AddColumn("dbo.UserEvents", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Id");
            AddPrimaryKey("dbo.UserEvents", "Id");
            AddForeignKey("dbo.UserEvents", "EventId", "dbo.Events", "Id");
            DropColumn("dbo.Events", "Id_event");
            DropColumn("dbo.Events", "EventName");
            DropColumn("dbo.Events", "EventTheme");
            DropColumn("dbo.Events", "EventLocation");
            DropColumn("dbo.Events", "EventDescription");
            DropColumn("dbo.UserEvents", "Id_UserEvents");
        }

        public override void Down()
        {
            AddColumn("dbo.UserEvents", "Id_UserEvents", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Events", "EventDescription", c => c.String());
            AddColumn("dbo.Events", "EventLocation", c => c.String());
            AddColumn("dbo.Events", "EventTheme", c => c.String());
            AddColumn("dbo.Events", "EventName", c => c.String());
            AddColumn("dbo.Events", "Id_event", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.UserEvents", "EventId", "dbo.Events");
            DropPrimaryKey("dbo.UserEvents");
            DropPrimaryKey("dbo.Events");
            DropColumn("dbo.UserEvents", "Id");
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Location");
            DropColumn("dbo.Events", "Theme");
            DropColumn("dbo.Events", "Name");
            DropColumn("dbo.Events", "Id");
            AddPrimaryKey("dbo.UserEvents", "Id_UserEvents");
            AddPrimaryKey("dbo.Events", "Id");
            RenameIndex(table: "dbo.UserEvents", name: "IX_EventId", newName: "IX_Id_Event");
            RenameIndex(table: "dbo.UserEvents", name: "IX_UserId", newName: "IX_Id_Users");
            RenameColumn(table: "dbo.UserEvents", name: "EventId", newName: "Id_Event");
            RenameColumn(table: "dbo.UserEvents", name: "UserId", newName: "Id_Users");
            AddForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events", "Id_event");
        }
    }
}
