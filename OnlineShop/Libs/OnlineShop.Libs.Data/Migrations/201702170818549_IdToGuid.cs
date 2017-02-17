namespace OnlineShop.Libs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdToGuid : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
        }
    }
}
