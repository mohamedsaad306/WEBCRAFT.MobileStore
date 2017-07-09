namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransactionModelTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Type_Id", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Type_Id", newName: "TypeId");
            AlterColumn("dbo.Transactions", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "TypeId");
            AddForeignKey("dbo.Transactions", "TypeId", "dbo.TransactionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TypeId", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TypeId" });
            AlterColumn("dbo.Transactions", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "TypeId", newName: "Type_Id");
            CreateIndex("dbo.Transactions", "Type_Id");
            AddForeignKey("dbo.Transactions", "Type_Id", "dbo.TransactionTypes", "Id");
        }
    }
}
