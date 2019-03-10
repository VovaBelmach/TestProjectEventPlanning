namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id_event = c.String(nullable: false, maxLength: 128),
                        EventName = c.String(),
                        EventTheme = c.String(),
                        EventLocation = c.String(),
                        EventDescription = c.String(),
                        NumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_event);
            
            CreateTable(
                "dbo.UserEvents",
                c => new
                    {
                        Id_UserEvents = c.String(nullable: false, maxLength: 128),
                        Id_Users = c.String(nullable: false, maxLength: 128),
                        Id_Event = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id_UserEvents)
                .ForeignKey("dbo.Events", t => t.Id_Event)
                .ForeignKey("dbo.AspNetUsers", t => t.Id_Users)
                .Index(t => t.Id_Users)
                .Index(t => t.Id_Event);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEvents", "Id_Users", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events");
            DropIndex("dbo.UserEvents", new[] { "Id_Event" });
            DropIndex("dbo.UserEvents", new[] { "Id_Users" });
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.UserEvents");
            DropTable("dbo.Events");
        }
    }
}
