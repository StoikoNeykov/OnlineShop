namespace OnlineShop.Libs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotosInsideProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhotoItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.PhotoItems", new[] { "Product_Id" });
            AddColumn("dbo.Products", "Photo1", c => c.String(nullable: false));
            AddColumn("dbo.Products", "Photo2", c => c.String());
            AddColumn("dbo.Products", "Photo3", c => c.String());
            AddColumn("dbo.Products", "Photo4", c => c.String());
            DropTable("dbo.PhotoItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhotoItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        SmallSizeUrl = c.String(nullable: false, maxLength: 200),
                        FullSizeUrl = c.String(nullable: false, maxLength: 200),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Products", "Photo4");
            DropColumn("dbo.Products", "Photo3");
            DropColumn("dbo.Products", "Photo2");
            DropColumn("dbo.Products", "Photo1");
            CreateIndex("dbo.PhotoItems", "Product_Id");
            AddForeignKey("dbo.PhotoItems", "Product_Id", "dbo.Products", "Id");
        }
    }
}
