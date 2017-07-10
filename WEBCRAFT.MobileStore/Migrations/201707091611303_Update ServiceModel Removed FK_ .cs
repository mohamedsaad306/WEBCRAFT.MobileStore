namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateServiceModelRemovedFK_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ExtraFeesId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "ServiceTypId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "ServiceBalenceId", c => c.Int(nullable: false));
            DropColumn("dbo.Services", "FK_ExtraFeesId");
            DropColumn("dbo.Services", "FK_ServiceTypId");
            DropColumn("dbo.Services", "FK_ServiceBalenceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "FK_ServiceBalenceId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "FK_ServiceTypId", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "FK_ExtraFeesId", c => c.Int(nullable: false));
            DropColumn("dbo.Services", "ServiceBalenceId");
            DropColumn("dbo.Services", "ServiceTypId");
            DropColumn("dbo.Services", "ExtraFeesId");
        }
    }
}
