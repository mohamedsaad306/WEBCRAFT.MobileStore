namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceableServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoicableServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_ServiceId = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        Service_Id = c.Int(),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasExtraFees = c.Boolean(nullable: false),
                        Comment = c.String(),
                        FK_ExtraFeesId = c.Int(nullable: false),
                        FK_ServiceTypId = c.Int(nullable: false),
                        FK_ServiceBalenceId = c.Int(nullable: false),
                        ExtraFeesType_Id = c.Int(),
                        ServiceBalance_Id = c.Int(),
                        ServiceType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExtraFeesTypes", t => t.ExtraFeesType_Id)
                .ForeignKey("dbo.ServiceBalances", t => t.ServiceBalance_Id)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceType_Id)
                .Index(t => t.ExtraFeesType_Id)
                .Index(t => t.ServiceBalance_Id)
                .Index(t => t.ServiceType_Id);
            
            CreateTable(
                "dbo.ExtraFeesTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceBalances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BalanceName = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HasBalance = c.Boolean(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoicableServices", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.InvoicableServices", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Services", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.Services", "ServiceBalance_Id", "dbo.ServiceBalances");
            DropForeignKey("dbo.Services", "ExtraFeesType_Id", "dbo.ExtraFeesTypes");
            DropIndex("dbo.InvoicableServices", new[] { "Invoice_Id" });
            DropIndex("dbo.InvoicableServices", new[] { "Service_Id" });
            DropIndex("dbo.Services", new[] { "ServiceType_Id" });
            DropIndex("dbo.Services", new[] { "ServiceBalance_Id" });
            DropIndex("dbo.Services", new[] { "ExtraFeesType_Id" });
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.ServiceBalances");
            DropTable("dbo.ExtraFeesTypes");
            DropTable("dbo.Services");
            DropTable("dbo.InvoicableServices");
        }
    }
}
