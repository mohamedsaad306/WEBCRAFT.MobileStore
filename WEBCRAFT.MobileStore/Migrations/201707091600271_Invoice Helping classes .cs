namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceHelpingclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoicableProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.Invoice_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoicableProducts", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.InvoicableProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.InvoicableProducts", new[] { "Invoice_Id" });
            DropIndex("dbo.InvoicableProducts", new[] { "Product_Id" });
            DropTable("dbo.InvoicableProducts");
        }
    }
}
