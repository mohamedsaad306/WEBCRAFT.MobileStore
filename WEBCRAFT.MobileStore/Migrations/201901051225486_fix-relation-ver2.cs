namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrelationver2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Inventory_Id", "dbo.Inventories");
            DropIndex("dbo.Products", new[] { "Inventory_Id" });
            AddColumn("dbo.StockItems", "Product_Id1", c => c.Int());
            AddColumn("dbo.StockItems", "Inventory_Id1", c => c.Int());
            CreateIndex("dbo.InventoryPreservedProducts", "ProductId");
            CreateIndex("dbo.StockItems", "Product_Id1");
            CreateIndex("dbo.StockItems", "Inventory_Id1");
            AddForeignKey("dbo.InventoryPreservedProducts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StockItems", "Product_Id1", "dbo.Products", "Id");
            AddForeignKey("dbo.StockItems", "Inventory_Id1", "dbo.Inventories", "Id");
            DropColumn("dbo.Products", "Inventory_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Inventory_Id", c => c.Int());
            DropForeignKey("dbo.StockItems", "Inventory_Id1", "dbo.Inventories");
            DropForeignKey("dbo.StockItems", "Product_Id1", "dbo.Products");
            DropForeignKey("dbo.InventoryPreservedProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.StockItems", new[] { "Inventory_Id1" });
            DropIndex("dbo.StockItems", new[] { "Product_Id1" });
            DropIndex("dbo.InventoryPreservedProducts", new[] { "ProductId" });
            DropColumn("dbo.StockItems", "Inventory_Id1");
            DropColumn("dbo.StockItems", "Product_Id1");
            CreateIndex("dbo.Products", "Inventory_Id");
            AddForeignKey("dbo.Products", "Inventory_Id", "dbo.Inventories", "Id");
        }
    }
}
