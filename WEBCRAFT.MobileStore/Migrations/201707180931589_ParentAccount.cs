namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ParentAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Accounts", "ParentAccount_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "ParentAccount_Id");
            AddForeignKey("dbo.Accounts", "ParentAccount_Id", "dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "ParentAccount_Id", "dbo.Accounts");
            DropIndex("dbo.Accounts", new[] { "ParentAccount_Id" });
            DropColumn("dbo.Accounts", "ParentAccount_Id");
            DropColumn("dbo.Accounts", "Balance");
        }
    }
}
