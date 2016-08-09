using CaffeGest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Services
{
    public class ProduitsServices
    {
        public static List<Produit> GetAllProduits()
        {
            List<Produit> LesProduits = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                LesProduits = ctx.Produits.Include("Categorie").ToList();
            }
            return LesProduits;
        }

        public static void AddProduit(Produit produit)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Produits.Add(produit);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Produit produit = GetById(id, ctx);
                ctx.Produits.Remove(produit);
                ctx.SaveChanges();
            }
        }

        public static Produit GetById(int id, ApplicationDbContext ctx = null)
        {
            Produit p = null;
            if (ctx != null)
            {
                p = ctx.Produits.Include("Categorie").Where(prod => prod.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    p = ctx.Produits.Include("Categorie").Where(prod => prod.Id == id).FirstOrDefault();
                }
            }
            return p;
        }

        public static void Edit(Produit prod)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Produit p = GetById(prod.Id,ctx);
                if (p != null)
                {
                    p.Nom = prod.Nom;
                    p.PU = prod.PU;
                    p.QuantiteStock = prod.QuantiteStock;
                    p.Poids = prod.Poids;
                    p.CategorieId = prod.CategorieId;
                    ctx.SaveChanges();
                }
                ctx.SaveChanges();
            }
        }
    }
}