using CaffeGest.Models;
using CaffeGest.Models.DAL;
using System;
using System.Collections.Generic;
using System.IO;
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
                LesProduits = ctx.Produits.Include("Categorie").Include("Fournisseurs").ToList();
            }
            return LesProduits;
        }

        public static void AddProduit(Produit produit)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                produit.Fournisseurs = FournisseurServices.GetFournisseurs(produit.FournisseursId, ctx);
               
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
                Produit p = GetById(prod.Id, ctx);
                p.Fournisseurs = FournisseurServices.GetFournisseurs(prod.FournisseursId, ctx);
                
                if (p != null)
                {
                    p.Nom = prod.Nom;
                    p.PU = prod.PU;
                    p.QuantiteStock = prod.QuantiteStock;
                    p.Poids = prod.Poids;
                    p.CategorieId = prod.CategorieId;
                    List<int> oldIds = p.FournisseursId;
                    List<int> newIds = null;
                    if(prod.FournisseursId != null)
                    {
                        newIds = prod.FournisseursId;
                    }
                    else
                    {
                        newIds = new List<int>();
                    }
                    prod.Fournisseurs = FournisseurServices.GetFournisseurs(prod.FournisseursId, ctx);
                    ctx.SaveChanges();
                }
                ctx.SaveChanges();
            }
        }
    }
}