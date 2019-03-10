namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events");
            DropIndex("dbo.UserEvents", new[] { "Id_Event" });
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Id_event", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserEvents", "Id_Event", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Events", "Id_event");
            CreateIndex("dbo.UserEvents", "Id_Event");
            AddForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events", "Id_event");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events");
            DropIndex("dbo.UserEvents", new[] { "Id_Event" });
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.UserEvents", "Id_Event", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Events", "Id_event", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Events", "Id_event");
            CreateIndex("dbo.UserEvents", "Id_Event");
            AddForeignKey("dbo.UserEvents", "Id_Event", "dbo.Events", "Id_event");
        }
    }
}
