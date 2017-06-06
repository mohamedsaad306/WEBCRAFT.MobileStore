namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Brand_PartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fk_BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "FK_BrandId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "FK_PartModelId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Brand_Id", c => c.Int());
            AddColumn("dbo.Products", "PartModel_Id", c => c.Int());
            CreateIndex("dbo.Products", "Brand_Id");
            CreateIndex("dbo.Products", "PartModel_Id");
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brands", "Id");
            AddForeignKey("dbo.Products", "PartModel_Id", "dbo.PartModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "PartModel_Id", "dbo.PartModels");
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "PartModel_Id" });
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            DropColumn("dbo.Products", "PartModel_Id");
            DropColumn("dbo.Products", "Brand_Id");
            DropColumn("dbo.Products", "FK_PartModelId");
            DropColumn("dbo.Products", "FK_BrandId");
            DropTable("dbo.PartModels");
            DropTable("dbo.Brands");
        }
    }
}
