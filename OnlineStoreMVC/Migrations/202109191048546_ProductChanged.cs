namespace OnlineStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OrdersNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OrdersNumber");
        }
    }
}
