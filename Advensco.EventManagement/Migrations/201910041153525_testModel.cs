namespace Advensco.EventManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TestModels");
        }
    }
}
