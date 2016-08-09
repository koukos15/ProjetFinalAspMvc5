using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class DepenseManager
    {
        public static void Add(Depense depense)
        {
            try
            {
                using (ApplicationDbContext ctx = new ApplicationDbContext())
                {
                    ctx.Depenses.Add(depense);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //mettre le message d'exception
            }
        }

        public static List<Depense> GetAll(DateTime dateDebut, DateTime dateFin)
        {
            List<Depense> depenses = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                //eager loading
                depenses = ctx.Depenses.Where(d => d.DateDepense >= dateDebut && d.DateDepense <= dateFin).ToList();
            }
            return depenses;
        }

        public static void Edit(Depense depense)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Depense uneDepense = GetById(depense.Id, ctx);

                uneDepense.DateDepense = depense.DateDepense;
                uneDepense.Description = depense.Description;
                uneDepense.Montant = depense.Montant;

                ctx.SaveChanges();
            }
        }

        public static void delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Depense depense = GetById(id, ctx);
                ctx.Depenses.Remove(depense);
                ctx.SaveChanges();

            }
        }

        public static Depense GetById(int id, ApplicationDbContext ctx = null)
        {
            Depense depense = null;
            if (ctx != null)
            {
                depense = ctx.Depenses.Where(d => d.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    depense = ctx.Depenses.Where(d => d.Id == id).FirstOrDefault();
                }
            }

            return depense;
        }
    }
}