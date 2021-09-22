namespace OnlineStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageSrc = c.String(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
            AddColumn("dbo.Products", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "Product_Id", "dbo.Products");
            DropIndex("dbo.ImageModels", new[] { "Product_Id" });
            DropColumn("dbo.Products", "Title");
            DropTable("dbo.ImageModels");
        }
    }
}
