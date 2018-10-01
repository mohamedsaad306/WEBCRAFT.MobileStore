namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Category_refactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "PartModel_Id", "dbo.PartModels");
            DropIndex("dbo.Products", new[] { "PartModel_Id" });
            RenameColumn(table: "dbo.Products", name: "Brand_Id", newName: "Category_Id");
            RenameIndex(table: "dbo.Products", name: "IX_Brand_Id", newName: "IX_Category_Id");
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fk_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "FK_CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "FK_SubcategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Subcategory_Id", c => c.Int());
            CreateIndex("dbo.Products", "Subcategory_Id");
            AddForeignKey("dbo.Products", "Subcategory_Id", "dbo.Subcategories", "Id");
            DropColumn("dbo.Products", "FK_BrandId");
            DropColumn("dbo.Products", "FK_PartModelId");
            DropColumn("dbo.Products", "PartModel_Id");
            DropTable("dbo.PartModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PartModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Fk_BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "PartModel_Id", c => c.Int());
            AddColumn("dbo.Products", "FK_PartModelId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "FK_BrandId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Subcategory_Id", "dbo.Subcategories");
            DropIndex("dbo.Products", new[] { "Subcategory_Id" });
            DropColumn("dbo.Products", "Subcategory_Id");
            DropColumn("dbo.Products", "FK_SubcategoryId");
            DropColumn("dbo.Products", "FK_CategoryId");
            DropTable("dbo.Subcategories");
            RenameIndex(table: "dbo.Products", name: "IX_Category_Id", newName: "IX_Brand_Id");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "Brand_Id");
            CreateIndex("dbo.Products", "PartModel_Id");
            AddForeignKey("dbo.Products", "PartModel_Id", "dbo.PartModels", "Id");
        }
    }
}
