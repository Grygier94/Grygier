namespace GrygierSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMarketUrlColumnToProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "MarketUrl", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "MarketUrl");
        }
    }
}
