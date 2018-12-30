namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEventwithmtom : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InventoryProducts1", newName: "ProductInventories");
            DropPrimaryKey("dbo.ProductInventories");
            CreateTable(
                "dbo.InventoryEvents",
                c => new
                    {
                        Inventory_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inventory_Id, t.Event_Id })
                .ForeignKey("dbo.Inventories", t => t.Inventory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Inventory_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.ProductEvents",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Event_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Event_Id);
            
            AddColumn("dbo.InventoryProducts", "Event_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductInventories", new[] { "Product_Id", "Inventory_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.ProductEvents", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.InventoryEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.InventoryEvents", "Inventory_Id", "dbo.Inventories");
            DropIndex("dbo.ProductEvents", new[] { "Event_Id" });
            DropIndex("dbo.ProductEvents", new[] { "Product_Id" });
            DropIndex("dbo.InventoryEvents", new[] { "Event_Id" });
            DropIndex("dbo.InventoryEvents", new[] { "Inventory_Id" });
            DropPrimaryKey("dbo.ProductInventories");
            DropColumn("dbo.InventoryProducts", "Event_Id");
            DropTable("dbo.ProductEvents");
            DropTable("dbo.InventoryEvents");
            AddPrimaryKey("dbo.ProductInventories", new[] { "Inventory_Id", "Product_Id" });
            RenameTable(name: "dbo.ProductInventories", newName: "InventoryProducts1");
        }
    }
}
