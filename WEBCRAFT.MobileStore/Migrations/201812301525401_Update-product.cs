namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImagePath", c => c.String());
            AddColumn("dbo.Products", "Barcode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Barcode");
            DropColumn("dbo.Products", "ImagePath");
        }
    }
}
