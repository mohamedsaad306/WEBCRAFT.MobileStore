namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePartModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartModels", "brand_Id", "dbo.Brands");
            DropIndex("dbo.PartModels", new[] { "brand_Id" });
            DropColumn("dbo.PartModels", "brand_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartModels", "brand_Id", c => c.Int());
            CreateIndex("dbo.PartModels", "brand_Id");
            AddForeignKey("dbo.PartModels", "brand_Id", "dbo.Brands", "Id");
        }
    }
}
