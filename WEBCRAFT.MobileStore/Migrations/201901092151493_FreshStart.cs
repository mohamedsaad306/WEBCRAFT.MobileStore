namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FreshStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FK_ParentAccountId = c.Int(nullable: false),
                        FK_TypeId = c.Int(nullable: false),
                        PartnerId = c.Int(nullable: false),
                        ParentAccount_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.ParentAccount_Id)
                .ForeignKey("dbo.AccountTypes", t => t.Type_Id)
                .Index(t => t.ParentAccount_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountId = c.Int(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.TransactionTypes", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.AccountId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FK_AccountId = c.Int(nullable: false),
                        Account_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
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
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_CustomerId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        InvoiceStatus_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.InvoiceStatus", t => t.InvoiceStatus_Id)
                .ForeignKey("dbo.InvoiceTypes", t => t.Type_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.InvoiceStatus_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.InvoicableProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.ProductId)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FK_CategoryId = c.Int(nullable: false),
                        FK_SubcategoryId = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePath = c.String(),
                        Barcode = c.String(),
                        Category_Id = c.Int(),
                        StockItems_Id = c.Int(),
                        Subcategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.StockItems", t => t.StockItems_Id)
                .ForeignKey("dbo.Subcategories", t => t.Subcategory_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.StockItems_Id)
                .Index(t => t.Subcategory_Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StockItems_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockItems", t => t.StockItems_Id)
                .Index(t => t.StockItems_Id);
            
            CreateTable(
                "dbo.StockItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventoryId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fk_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoicableServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.ServiceId)
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
                        ExtraFeesId = c.Int(nullable: false),
                        ServiceTypId = c.Int(nullable: false),
                        ServiceBalenceId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.InvoiceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.InventoryProducts",
                c => new
                    {
                        Inventory_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Inventory_Id, t.Product_Id })
                .ForeignKey("dbo.Inventories", t => t.Inventory_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Inventory_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "Type_Id", "dbo.InvoiceTypes");
            DropForeignKey("dbo.Invoices", "InvoiceStatus_Id", "dbo.InvoiceStatus");
            DropForeignKey("dbo.InvoicableServices", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.InvoicableServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Services", "ServiceType_Id", "dbo.ServiceTypes");
            DropForeignKey("dbo.Services", "ServiceBalance_Id", "dbo.ServiceBalances");
            DropForeignKey("dbo.Services", "ExtraFeesType_Id", "dbo.ExtraFeesTypes");
            DropForeignKey("dbo.InvoicableProducts", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.InvoicableProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Subcategory_Id", "dbo.Subcategories");
            DropForeignKey("dbo.Products", "StockItems_Id", "dbo.StockItems");
            DropForeignKey("dbo.InventoryPreservedProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Inventories", "StockItems_Id", "dbo.StockItems");
            DropForeignKey("dbo.InventoryProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.InventoryProducts", "Inventory_Id", "dbo.Inventories");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Invoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.InventoryPreservedProducts", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Type_Id", "dbo.AccountTypes");
            DropForeignKey("dbo.Transactions", "TypeId", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "ParentAccount_Id", "dbo.Accounts");
            DropIndex("dbo.InventoryProducts", new[] { "Product_Id" });
            DropIndex("dbo.InventoryProducts", new[] { "Inventory_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.Services", new[] { "ServiceType_Id" });
            DropIndex("dbo.Services", new[] { "ServiceBalance_Id" });
            DropIndex("dbo.Services", new[] { "ExtraFeesType_Id" });
            DropIndex("dbo.InvoicableServices", new[] { "Invoice_Id" });
            DropIndex("dbo.InvoicableServices", new[] { "ServiceId" });
            DropIndex("dbo.Inventories", new[] { "StockItems_Id" });
            DropIndex("dbo.Products", new[] { "Subcategory_Id" });
            DropIndex("dbo.Products", new[] { "StockItems_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.InvoicableProducts", new[] { "Invoice_Id" });
            DropIndex("dbo.InvoicableProducts", new[] { "ProductId" });
            DropIndex("dbo.Invoices", new[] { "Type_Id" });
            DropIndex("dbo.Invoices", new[] { "InvoiceStatus_Id" });
            DropIndex("dbo.Invoices", new[] { "Customer_Id" });
            DropIndex("dbo.InventoryPreservedProducts", new[] { "EventId" });
            DropIndex("dbo.InventoryPreservedProducts", new[] { "ProductId" });
            DropIndex("dbo.Events", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Account_Id" });
            DropIndex("dbo.Transactions", new[] { "TypeId" });
            DropIndex("dbo.Transactions", new[] { "AccountId" });
            DropIndex("dbo.Accounts", new[] { "Type_Id" });
            DropIndex("dbo.Accounts", new[] { "ParentAccount_Id" });
            DropTable("dbo.InventoryProducts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.InvoiceTypes");
            DropTable("dbo.InvoiceStatus");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.ServiceBalances");
            DropTable("dbo.ExtraFeesTypes");
            DropTable("dbo.Services");
            DropTable("dbo.InvoicableServices");
            DropTable("dbo.Subcategories");
            DropTable("dbo.StockItems");
            DropTable("dbo.Inventories");
            DropTable("dbo.Products");
            DropTable("dbo.InvoicableProducts");
            DropTable("dbo.Invoices");
            DropTable("dbo.InventoryPreservedProducts");
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}
