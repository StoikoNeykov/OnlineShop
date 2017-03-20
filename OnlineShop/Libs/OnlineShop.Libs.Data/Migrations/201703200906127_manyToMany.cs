namespace OnlineShop.Libs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductsCategories",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CategoryId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductsCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductsCategories", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductsCategories", new[] { "CategoryId" });
            DropIndex("dbo.ProductsCategories", new[] { "ProductId" });
            DropTable("dbo.ProductsCategories");
        }
    }
}
