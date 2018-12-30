namespace WEBCRAFT.MobileStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class todrop : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProductEvents");
            DropTable("dbo.InventoryEvents");
        }
        
        public override void Down()
        {
        }
    }
}
