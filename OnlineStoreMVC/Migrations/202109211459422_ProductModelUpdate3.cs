namespace OnlineStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImgSources", c => c.String());
            AddColumn("dbo.Products", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discriminator");
            DropColumn("dbo.Products", "ImgSources");
        }
    }
}
