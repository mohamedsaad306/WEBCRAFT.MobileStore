namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryEvents", "Inventory_Id", "dbo.Inventories");
            DropForeignKey("dbo.InventoryEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.ProductEvents", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.ProductInventories", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductInventories", "Inventory_Id", "dbo.Inventories");
            DropIndex("dbo.InventoryEvents", new[] { "Inventory_Id" });
            DropIndex("dbo.InventoryEvents", new[] { "Event_Id" });
            DropIndex("dbo.ProductEvents", new[] { "Product_Id" });
            DropIndex("dbo.ProductEvents", new[] { "Event_Id" });
            DropIndex("dbo.ProductInventories", new[] { "Product_Id" });
            DropIndex("dbo.ProductInventories", new[] { "Inventory_Id" });
            CreateTable(
                "dbo.InventoryPreservedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        PreservedQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.StockItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inventory_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Inventory_Id", c => c.Int());
            CreateIndex("dbo.Products", "Inventory_Id");
            AddForeignKey("dbo.Products", "Inventory_Id", "dbo.Inventories", "Id");
            DropTable("dbo.InventoryProducts");
           
           
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductInventories",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Inventory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Inventory_Id });
            
            CreateTable(
                "dbo.ProductEvents",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Event_Id });
            
            CreateTable(
                "dbo.InventoryEvents",
                c => new
                    {
                        Inventory_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inventory_Id, t.Event_Id });
            
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inventory_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "Inventory_Id", "dbo.Inventories");
            DropForeignKey("dbo.InventoryPreservedProducts", "EventId", "dbo.Events");
            DropIndex("dbo.Products", new[] { "Inventory_Id" });
            DropIndex("dbo.InventoryPreservedProducts", new[] { "EventId" });
            DropColumn("dbo.Products", "Inventory_Id");
            DropTable("dbo.StockItems");
            DropTable("dbo.InventoryPreservedProducts");
            CreateIndex("dbo.ProductInventories", "Inventory_Id");
            CreateIndex("dbo.ProductInventories", "Product_Id");
            CreateIndex("dbo.ProductEvents", "Event_Id");
            CreateIndex("dbo.ProductEvents", "Product_Id");
            CreateIndex("dbo.InventoryEvents", "Event_Id");
            CreateIndex("dbo.InventoryEvents", "Inventory_Id");
            AddForeignKey("dbo.ProductInventories", "Inventory_Id", "dbo.Inventories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductInventories", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductEvents", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductEvents", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryEvents", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryEvents", "Inventory_Id", "dbo.Inventories", "Id", cascadeDelete: true);
        }
    }
}
