namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEventwith1tomcustomer : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.InventoryProducts", newName: "InventoryProducts1");
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_CustomerId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Owner = c.String(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inventory_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Events", new[] { "Customer_Id" });
            DropTable("dbo.InventoryProducts");
            DropTable("dbo.Events");
            RenameTable(name: "dbo.InventoryProducts1", newName: "InventoryProducts");
        }
    }
}
