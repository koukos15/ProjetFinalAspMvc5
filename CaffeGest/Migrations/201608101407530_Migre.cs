namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migre : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FournisseurProduits", newName: "ProduitFournisseurs");
            DropForeignKey("dbo.Photos", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Produits", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.Produits", "Photo_Id1", "dbo.Photos");
            DropIndex("dbo.Produits", new[] { "Photo_Id" });
            DropIndex("dbo.Produits", new[] { "Photo_Id1" });
            DropIndex("dbo.Photos", new[] { "ProduitId" });
            DropPrimaryKey("dbo.ProduitFournisseurs");
            AddPrimaryKey("dbo.ProduitFournisseurs", new[] { "Produit_Id", "Fournisseur_Id" });
            DropColumn("dbo.Produits", "Photo_Id");
            DropColumn("dbo.Produits", "Photo_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produits", "Photo_Id1", c => c.Int());
            AddColumn("dbo.Produits", "Photo_Id", c => c.Int());
            DropPrimaryKey("dbo.ProduitFournisseurs");
            AddPrimaryKey("dbo.ProduitFournisseurs", new[] { "Fournisseur_Id", "Produit_Id" });
            CreateIndex("dbo.Photos", "ProduitId");
            CreateIndex("dbo.Produits", "Photo_Id1");
            CreateIndex("dbo.Produits", "Photo_Id");
            AddForeignKey("dbo.Produits", "Photo_Id1", "dbo.Photos", "Id");
            AddForeignKey("dbo.Produits", "Photo_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Photos", "ProduitId", "dbo.Produits", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ProduitFournisseurs", newName: "FournisseurProduits");
        }
    }
}
