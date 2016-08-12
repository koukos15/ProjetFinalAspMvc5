using CaffeGest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class AchatManager
    {
        public static void Add(Achat unAchat)
        {
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    //mise a jour de la quntite du produit
                    Produit unProduit = ProduitsServices.GetById(unAchat.ProduitId, ctx);
                    unProduit.QuantiteStock += unAchat.QteAchetee;

                    ctx.Achats.Add(unAchat);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //mettre le message d'exception
            }
        }

        public static List<Achat> GetAll(DateTime dateDebut, DateTime dateFin)
        {
            List<Achat> mesAchats = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                //eager loading
                mesAchats = ctx.Achats.Include("Produit").Include("Fournisseur").Where(a => a.DateAchat >= dateDebut && a.DateAchat <= dateFin).ToList();
            }
            return mesAchats;
        }

        public static void Edit(Achat unAchat)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Achat achat = GetById(unAchat.Id, ctx);

                //mise a jour de la quantite du produit
                int qte = unAchat.QteAchetee - achat.QteAchetee;
                Produit unProduit = ProduitsServices.GetById(unAchat.ProduitId, ctx);
                unProduit.QuantiteStock += qte;

                achat.DateAchat = unAchat.DateAchat;
                achat.QteAchetee = unAchat.QteAchetee;
                achat.Montant = unAchat.Montant;
                achat.ProduitId = unAchat.ProduitId;
                achat.FournisseurId = unAchat.FournisseurId;
                
                ctx.SaveChanges();
            }
        }

        public static void delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Achat unAchat = GetById(id, ctx);
                ctx.Achats.Remove(unAchat);
                ctx.SaveChanges();

            }
        }

        public static Achat GetById(int id, ApplicationDbContext ctx = null)
        {
            Achat unAchat = null;
            if (ctx != null)
            {
                unAchat = ctx.Achats.Include("Produit").Include("Fournisseur").Where(a => a.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    unAchat = ctx.Achats.Include("Produit").Include("Fournisseur").Where(a => a.Id == id).FirstOrDefault();
                }
            }

            return unAchat;
        }
    }
}