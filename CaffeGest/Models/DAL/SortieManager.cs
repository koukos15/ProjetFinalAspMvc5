using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class SortieManager
    {
        public static void Add(Sortie uneSortie)
        {
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    ctx.Sorties.Add(uneSortie);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //mettre le message d'exception
            }
        }

        public static List<Sortie> GetAll(DateTime dateDebut, DateTime dateFin, string typeSortie)
        {
            List<Sortie> mesSorties = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                //eager loading
                mesSorties = ctx.Sorties.Include("TypeSortie").Include("Produit").Include("Client").Where(s => s.DateSortie >= dateDebut && s.DateSortie <= dateFin && s.TypeSortie.Nom == typeSortie).ToList();
            }
            return mesSorties;
        }

        public static void Edit(Sortie sortie)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Sortie uneSortie = GetById(sortie.Id, ctx);
                uneSortie.DateSortie = sortie.DateSortie;
                uneSortie.ClientId = sortie.ClientId;
                uneSortie.Montant = sortie.Montant;
                uneSortie.ProduitId = sortie.ProduitId;
                uneSortie.QteSortie = sortie.QteSortie;
                uneSortie.TypeSortieId = sortie.TypeSortieId;

                ctx.SaveChanges();
            }
        }

        public static void delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Sortie sortie = GetById(id, ctx);
                ctx.Sorties.Remove(sortie);
                ctx.SaveChanges();

            }
        }

        public static Sortie GetById(int id, ApplicationDbContext ctx = null)
        {
            Sortie sortie = null;
            if (ctx != null)
            {
                sortie = ctx.Sorties.Include("TypeSortie").Include("Produit").Include("Client").Where(s => s.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    sortie = ctx.Sorties.Include("TypeSortie").Include("Produit").Include("Client").Where(a => a.Id == id).FirstOrDefault();
                }
            }

            return sortie;
        }
    }
}