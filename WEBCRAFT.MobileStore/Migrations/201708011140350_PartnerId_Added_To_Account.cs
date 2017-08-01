namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartnerId_Added_To_Account : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "PartnerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "PartnerId");
        }
    }
}
