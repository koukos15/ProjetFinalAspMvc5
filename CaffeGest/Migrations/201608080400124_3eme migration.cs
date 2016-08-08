namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3ememigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Entrees", newName: "Achats");
            RenameTable(name: "dbo.FournisseurProduits", newName: "ProduitFournisseurs");
            DropPrimaryKey("dbo.ProduitFournisseurs");
            AddColumn("dbo.Achats", "DateAchat", c => c.DateTime(nullable: false));
            AddColumn("dbo.Achats", "QteAchetee", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProduitFournisseurs", new[] { "Produit_Id", "Fournisseur_Id" });
            DropColumn("dbo.Achats", "DateEntree");
            DropColumn("dbo.Achats", "QteEntree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achats", "QteEntree", c => c.Int(nullable: false));
            AddColumn("dbo.Achats", "DateEntree", c => c.DateTime(nullable: false));
            DropPrimaryKey("dbo.ProduitFournisseurs");
            DropColumn("dbo.Achats", "QteAchetee");
            DropColumn("dbo.Achats", "DateAchat");
            AddPrimaryKey("dbo.ProduitFournisseurs", new[] { "Fournisseur_Id", "Produit_Id" });
            RenameTable(name: "dbo.ProduitFournisseurs", newName: "FournisseurProduits");
            RenameTable(name: "dbo.Achats", newName: "Entrees");
        }
    }
}
