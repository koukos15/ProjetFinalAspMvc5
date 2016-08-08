using CaffeGest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Services
{
    public class CategoriesServices
    {
        public static List<Categorie> GetAllCategories()
        {
            List<Categorie> LesCategories = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                LesCategories = ctx.Categories.ToList();
            }
            return LesCategories;
        }

        public static void AddProduit(Categorie categorie)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(categorie);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Categorie categorie = GetById(id, ctx);
                ctx.Categories.Remove(categorie);
                ctx.SaveChanges();
            }
        }

        public static Categorie GetById(int id, ApplicationDbContext ctx = null)
        {
            Categorie cat = null;
            if (ctx != null)
            {
                cat = ctx.Categories.Where(c => c.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    cat = ctx.Categories.Where(c => c.Id == id).FirstOrDefault();
                }
            }
            return cat;
        }
        public static void Edit(Categorie cat)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Categorie c = GetById(cat.Id, ctx);
                if (c != null)
                {
                    c.Nom = cat.Nom;

                    ctx.SaveChanges();
                }
                ctx.SaveChanges();
            }
        }
    }
}