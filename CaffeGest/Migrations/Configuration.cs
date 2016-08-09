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
          //  AddSomeProduits(context);
           // AddSomeCategories(context);
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
        private void AddSomeProduits(CaffeGest.Models.ApplicationDbContext context)
        {
            List<Produit> LesProduits = new List<Produit>
            {
                new Produit {Nom="LE Bon Cafe",PU = 25,Grammage=50,QuantiteStock=400 },
                new Produit {Nom="LE Bon Cafe",PU = 45,Grammage=100,QuantiteStock=300 },
                new Produit {Nom="Amina",PU = 20,Grammage=50,QuantiteStock=270 },
                new Produit {Nom="Amina",PU = 32,Grammage=100,QuantiteStock=350 }
            };
            context.Produits.AddRange(LesProduits);
        }
        private void AddSomeCategories(CaffeGest.Models.ApplicationDbContext context)
        {
            List<Categorie> LesCategories = new List<Categorie>
            {
                new Categorie { Nom="Produits finis"},
                new Categorie { Nom="Matiere 1ere"}
            };
            context.Categories.AddRange(LesCategories);
        }

    }
}
