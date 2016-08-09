using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class FournisseurServices
    {

        public static List<Fournisseur> GetAllFournisseurs()
        {

            List<Fournisseur> lesFourniseurs = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                lesFourniseurs = ctx.Fournissseurs.Include("Produits").ToList();
                ctx.SaveChanges();
            }
            return lesFourniseurs;
        }

        public static void Add(Fournisseur fournisseur)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Fournissseurs.Add(fournisseur);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Fournisseur fournisseur = GetById(id, ctx);
                ctx.Fournissseurs.Remove(fournisseur);
                ctx.SaveChanges();
            }
        }

        public static Fournisseur GetById(int id, ApplicationDbContext ctx = null)
        {
            Fournisseur f = null;
            if (ctx != null)
            {
                f = ctx.Fournissseurs.Include("Produits").Where(cl => cl.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    f = ctx.Fournissseurs.Include("Produits").Where(cl => cl.Id == id).FirstOrDefault();
                }
            }
            return f;
        }

        public static void Edit(Fournisseur fournisseur)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Fournisseur f = GetById(fournisseur.Id, ctx);
                if (f != null)
                {
                    f.Nom = fournisseur.Nom;
                    f.Email = fournisseur.Email;
                    f.Tel = fournisseur.Tel;
                }
                ctx.SaveChanges();
            }
        }

        public static List<Fournisseur> GetFournisseurs(List<int> ids, ApplicationDbContext ctx = null)
        {
            List<Fournisseur> Frs = null;
            if (ctx == null)
            {
                using (ctx = new ApplicationDbContext())
                {
                    Frs = ctx.Fournissseurs.Where(f => ids.Contains(f.Id)).ToList();
                }
            }
            else
            {
                Frs = ctx.Fournissseurs.Where(f => ids.Contains(f.Id)).ToList();
            }

            return Frs;
        }
    }
}
