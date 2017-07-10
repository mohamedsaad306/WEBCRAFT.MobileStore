namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransactionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "Account_Id" });
            AddColumn("dbo.Transactions", "Account_Id1", c => c.Int());
            AlterColumn("dbo.Transactions", "Account_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "Account_Id1");
            AddForeignKey("dbo.Transactions", "Account_Id1", "dbo.Accounts", "Id");
            //DropColumn("dbo.Transactions", "Transation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Transation_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "Account_Id1", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "Account_Id1" });
            AlterColumn("dbo.Transactions", "Account_Id", c => c.Int());
            DropColumn("dbo.Transactions", "Account_Id1");
            CreateIndex("dbo.Transactions", "Account_Id");
            AddForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts", "Id");
        }
    }
}
