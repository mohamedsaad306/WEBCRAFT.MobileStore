namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceUpdates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Invoices", "InvoiceStatus_Id", c => c.Int());
            CreateIndex("dbo.Invoices", "InvoiceStatus_Id");
            AddForeignKey("dbo.Invoices", "InvoiceStatus_Id", "dbo.InvoiceStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "InvoiceStatus_Id", "dbo.InvoiceStatus");
            DropIndex("dbo.Invoices", new[] { "InvoiceStatus_Id" });
            DropColumn("dbo.Invoices", "InvoiceStatus_Id");
            DropTable("dbo.InvoiceStatus");
        }
    }
}
