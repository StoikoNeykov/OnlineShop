namespace OnlineShop.Libs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ProductId = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.ProductId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhotoItems", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "ProductId" });
            DropIndex("dbo.PhotoItems", new[] { "Product_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.PhotoItems");
        }
    }
}
