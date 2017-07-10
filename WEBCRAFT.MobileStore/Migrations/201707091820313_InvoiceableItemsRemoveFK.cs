namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceableItemsRemoveFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoicableProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.InvoicableServices", "Service_Id", "dbo.Services");
            DropIndex("dbo.InvoicableProducts", new[] { "Product_Id" });
            DropIndex("dbo.InvoicableServices", new[] { "Service_Id" });
            RenameColumn(table: "dbo.InvoicableProducts", name: "Product_Id", newName: "ProductId");
            RenameColumn(table: "dbo.InvoicableServices", name: "Service_Id", newName: "ServiceId");
            AlterColumn("dbo.InvoicableProducts", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoicableServices", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoicableProducts", "ProductId");
            CreateIndex("dbo.InvoicableServices", "ServiceId");
            AddForeignKey("dbo.InvoicableProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InvoicableServices", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            DropColumn("dbo.InvoicableProducts", "FK_ProductId");
            DropColumn("dbo.InvoicableServices", "FK_ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InvoicableServices", "FK_ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.InvoicableProducts", "FK_ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.InvoicableServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.InvoicableProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.InvoicableServices", new[] { "ServiceId" });
            DropIndex("dbo.InvoicableProducts", new[] { "ProductId" });
            AlterColumn("dbo.InvoicableServices", "ServiceId", c => c.Int());
            AlterColumn("dbo.InvoicableProducts", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.InvoicableServices", name: "ServiceId", newName: "Service_Id");
            RenameColumn(table: "dbo.InvoicableProducts", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.InvoicableServices", "Service_Id");
            CreateIndex("dbo.InvoicableProducts", "Product_Id");
            AddForeignKey("dbo.InvoicableServices", "Service_Id", "dbo.Services", "Id");
            AddForeignKey("dbo.InvoicableProducts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
