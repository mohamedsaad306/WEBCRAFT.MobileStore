namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createnewrelation3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.InventoryProducts",
              c => new
              {
                  Inventory_Id = c.Int(nullable: false),
                  Product_Id = c.Int(nullable: false),
                  Amount = c.Int(nullable: false)
              })
              .PrimaryKey(t => new { t.Inventory_Id, t.Product_Id })
              .ForeignKey("dbo.Inventories", t => t.Inventory_Id, cascadeDelete: true)
              .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
              .Index(t => t.Inventory_Id)
              .Index(t => t.Product_Id);
        }
        
        public override void Down()
        {
        }
    }
}
