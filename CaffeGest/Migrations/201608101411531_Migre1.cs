namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migre1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Photos", "ProduitId");
            AddForeignKey("dbo.Photos", "ProduitId", "dbo.Produits", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "ProduitId", "dbo.Produits");
            DropIndex("dbo.Photos", new[] { "ProduitId" });
        }
    }
}
