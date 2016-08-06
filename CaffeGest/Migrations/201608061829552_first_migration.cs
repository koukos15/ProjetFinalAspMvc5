namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        PU = c.Double(nullable: false),
                        QuantiteStock = c.Int(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.Entrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEntree = c.DateTime(nullable: false),
                        QteEntree = c.Int(nullable: false),
                        Montant = c.Double(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        FournisseurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fournisseurs", t => t.FournisseurId, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .Index(t => t.ProduitId)
                .Index(t => t.FournisseurId);
            
            CreateTable(
                "dbo.Fournisseurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Tel = c.String(nullable: false),
                        Email = c.String(),
                        Adresse = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sorties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateSortie = c.DateTime(nullable: false),
                        QteSortie = c.Int(nullable: false),
                        Montant = c.Double(),
                        TypeSortieId = c.Int(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.TypeSorties", t => t.TypeSortieId, cascadeDelete: true)
                .Index(t => t.TypeSortieId)
                .Index(t => t.ProduitId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Tel = c.String(nullable: false),
                        Email = c.String(),
                        Adresse = c.String(),
                        TypeClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeClients", t => t.TypeClientId, cascadeDelete: true)
                .Index(t => t.TypeClientId);
            
            CreateTable(
                "dbo.TypeClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeSorties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Depenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Montant = c.Double(nullable: false),
                        DateDepense = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FournisseurProduits",
                c => new
                    {
                        Fournisseur_Id = c.Int(nullable: false),
                        Produit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fournisseur_Id, t.Produit_Id })
                .ForeignKey("dbo.Fournisseurs", t => t.Fournisseur_Id, cascadeDelete: true)
                .ForeignKey("dbo.Produits", t => t.Produit_Id, cascadeDelete: true)
                .Index(t => t.Fournisseur_Id)
                .Index(t => t.Produit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Sorties", "TypeSortieId", "dbo.TypeSorties");
            DropForeignKey("dbo.Sorties", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Sorties", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "TypeClientId", "dbo.TypeClients");
            DropForeignKey("dbo.Entrees", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Entrees", "FournisseurId", "dbo.Fournisseurs");
            DropForeignKey("dbo.FournisseurProduits", "Produit_Id", "dbo.Produits");
            DropForeignKey("dbo.FournisseurProduits", "Fournisseur_Id", "dbo.Fournisseurs");
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropIndex("dbo.FournisseurProduits", new[] { "Produit_Id" });
            DropIndex("dbo.FournisseurProduits", new[] { "Fournisseur_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Clients", new[] { "TypeClientId" });
            DropIndex("dbo.Sorties", new[] { "ClientId" });
            DropIndex("dbo.Sorties", new[] { "ProduitId" });
            DropIndex("dbo.Sorties", new[] { "TypeSortieId" });
            DropIndex("dbo.Entrees", new[] { "FournisseurId" });
            DropIndex("dbo.Entrees", new[] { "ProduitId" });
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            DropTable("dbo.FournisseurProduits");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Depenses");
            DropTable("dbo.TypeSorties");
            DropTable("dbo.TypeClients");
            DropTable("dbo.Clients");
            DropTable("dbo.Sorties");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Entrees");
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
