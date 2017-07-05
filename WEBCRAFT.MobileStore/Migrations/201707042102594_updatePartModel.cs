namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePartModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartModels", "brand_Id", c => c.Int());
            CreateIndex("dbo.PartModels", "brand_Id");
            AddForeignKey("dbo.PartModels", "brand_Id", "dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PartModels", "brand_Id", "dbo.Brands");
            DropIndex("dbo.PartModels", new[] { "brand_Id" });
            DropColumn("dbo.PartModels", "brand_Id");
        }
    }
}
