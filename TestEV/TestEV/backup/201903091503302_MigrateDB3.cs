namespace TestEV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserEvents");
            AlterColumn("dbo.UserEvents", "Id_UserEvents", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserEvents", "Id_UserEvents");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserEvents");
            AlterColumn("dbo.UserEvents", "Id_UserEvents", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UserEvents", "Id_UserEvents");
        }
    }
}
