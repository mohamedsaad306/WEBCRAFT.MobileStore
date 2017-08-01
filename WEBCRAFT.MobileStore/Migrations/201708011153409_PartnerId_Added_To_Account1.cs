namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartnerId_Added_To_Account1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "FK_ParentAccountId", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "FK_TypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "FK_TypeId");
            DropColumn("dbo.Accounts", "FK_ParentAccountId");
        }
    }
}
