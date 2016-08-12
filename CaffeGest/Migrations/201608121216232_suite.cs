namespace CaffeGest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAchat = c.DateTime(nullable: false),
                        QteAchetee = c.Int(nullable: false),
                        Montant = c.Double(nullable: false),
                        ProduitId = c.Int(nullable: false),
                        FournisseurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produits", t => t.ProduitId, cascadeDelete: true)
                .ForeignKey("dbo.Fournisseurs", t => t.FournisseurId, cascadeDelete: true)
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
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        PU = c.Double(nullable: false),
                        QuantiteStock = c.Int(nullable: false),
                        Poids = c.Int(nullable: false),
                        Img = c.String(),
                        CategorieId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.ProduitFournisseurs",
                c => new
                    {
                        Produit_Id = c.Int(nullable: false),
                        Fournisseur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produit_Id, t.Fournisseur_Id })
                .ForeignKey("dbo.Produits", t => t.Produit_Id, cascadeDelete: true)
                .ForeignKey("dbo.Fournisseurs", t => t.Fournisseur_Id, cascadeDelete: true)
                .Index(t => t.Produit_Id)
                .Index(t => t.Fournisseur_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Users", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Achats", "FournisseurId", "dbo.Fournisseurs");
            DropForeignKey("dbo.Sorties", "TypeSortieId", "dbo.TypeSorties");
            DropForeignKey("dbo.Sorties", "ProduitId", "dbo.Produits");
            DropForeignKey("dbo.Sorties", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "TypeClientId", "dbo.TypeClients");
            DropForeignKey("dbo.ProduitFournisseurs", "Fournisseur_Id", "dbo.Fournisseurs");
            DropForeignKey("dbo.ProduitFournisseurs", "Produit_Id", "dbo.Produits");
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Achats", "ProduitId", "dbo.Produits");
            DropIndex("dbo.ProduitFournisseurs", new[] { "Fournisseur_Id" });
            DropIndex("dbo.ProduitFournisseurs", new[] { "Produit_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "ApplicationUserId" });
            DropIndex("dbo.Clients", new[] { "TypeClientId" });
            DropIndex("dbo.Sorties", new[] { "ClientId" });
            DropIndex("dbo.Sorties", new[] { "ProduitId" });
            DropIndex("dbo.Sorties", new[] { "TypeSortieId" });
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            DropIndex("dbo.Achats", new[] { "FournisseurId" });
            DropIndex("dbo.Achats", new[] { "ProduitId" });
            DropTable("dbo.ProduitFournisseurs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.Depenses");
            DropTable("dbo.TypeSorties");
            DropTable("dbo.TypeClients");
            DropTable("dbo.Clients");
            DropTable("dbo.Sorties");
            DropTable("dbo.Categories");
            DropTable("dbo.Produits");
            DropTable("dbo.Fournisseurs");
            DropTable("dbo.Achats");
        }
    }
}
