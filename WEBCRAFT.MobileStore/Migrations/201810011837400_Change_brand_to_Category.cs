namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_brand_to_Category : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Brands", newName: "Categories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Categories", newName: "Brands");
        }
    }
}
