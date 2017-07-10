namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransactionModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Account_Id1", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "Account_Id1" });
            RenameColumn(table: "dbo.Transactions", name: "Account_Id1", newName: "AccountId");
            AlterColumn("dbo.Transactions", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "AccountId");
            AddForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
            DropColumn("dbo.Transactions", "Account_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Account_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            AlterColumn("dbo.Transactions", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "AccountId", newName: "Account_Id1");
            CreateIndex("dbo.Transactions", "Account_Id1");
            AddForeignKey("dbo.Transactions", "Account_Id1", "dbo.Accounts", "Id");
        }
    }
}
