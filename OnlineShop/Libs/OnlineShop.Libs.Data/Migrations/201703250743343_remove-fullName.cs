namespace OnlineShop.Libs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefullName : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "FullName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
