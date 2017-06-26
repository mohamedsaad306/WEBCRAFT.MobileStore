namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_AccountId = c.Int(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        Account_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.TransactionTypes", t => t.Type_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Type_Id);
            
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
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_CustomerId = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DueAmmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.InvoiceTypes", t => t.Type_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.InvoiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Type_Id", "dbo.InvoiceTypes");
            DropForeignKey("dbo.Invoices", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "Type_Id", "dbo.AccountTypes");
            DropForeignKey("dbo.Transactions", "Type_Id", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.Invoices", new[] { "Type_Id" });
            DropIndex("dbo.Invoices", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Account_Id" });
            DropIndex("dbo.Accounts", new[] { "Type_Id" });
            DropIndex("dbo.Transactions", new[] { "Type_Id" });
            DropIndex("dbo.Transactions", new[] { "Account_Id" });
            DropTable("dbo.InvoiceTypes");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Accounts");
        }
    }
}
