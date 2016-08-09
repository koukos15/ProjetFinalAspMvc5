namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            AlterColumn("dbo.Produits", "QuantiteStock", c => c.Int());
            AlterColumn("dbo.Produits", "CategorieId", c => c.Int());
            CreateIndex("dbo.Produits", "CategorieId");
            AddForeignKey("dbo.Produits", "CategorieId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            AlterColumn("dbo.Produits", "CategorieId", c => c.Int(nullable: false));
            AlterColumn("dbo.Produits", "QuantiteStock", c => c.Int(nullable: false));
            CreateIndex("dbo.Produits", "CategorieId");
            AddForeignKey("dbo.Produits", "CategorieId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
