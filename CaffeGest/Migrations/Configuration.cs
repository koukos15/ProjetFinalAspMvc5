namespace CaffeGest.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CaffeGest.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CaffeGest.Models.ApplicationDbContext context)
        {
            // AddSomeCategories(context);
            //AddSomeProduits(context);
            //AddSomeFournisseurs(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        private void AddSomeCategories(CaffeGest.Models.ApplicationDbContext context)
        {
            List<Categorie> Categories = new List<Categorie>
            {
                new Categorie { Nom = "Produits finis"},
                new Categorie { Nom = "Matiere 1ere"}
        };
            context.Categories.AddRange(Categories);
        }

        private void AddSomeProduits(CaffeGest.Models.ApplicationDbContext context)
        {
            List<Produit> produits = new List<Produit>
            {
                new Produit { Nom = "Amina", PU = 200, QuantiteStock=300,Poids=4000,CategorieId = 1},
                new Produit { Nom = "Arabica", PU = 200, QuantiteStock=300,Poids=4000, CategorieId =2}
        };
            context.Produits.AddRange(produits);
        }

        private void AddSomeFournisseurs(CaffeGest.Models.ApplicationDbContext context)
        {
            List<Fournisseur> fournisseurs = new List<Fournisseur>
            {
                new Fournisseur { Nom = "Andre", Tel = "514-589-6235", Email="toto@ysbh.ca",Adresse="124 avenue rosemont"},
                new Fournisseur { Nom = "Joey", Tel = "514-745-9854", Email="joey@gmail.com",Adresse="5142 boul de la cote"}
        };
            context.Fournissseurs.AddRange(fournisseurs);
        }
    }
}
