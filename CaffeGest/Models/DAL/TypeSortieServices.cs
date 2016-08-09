using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class TypeSortieServices
    {
        public static List<TypeSortie> GetAllTypeSorties()
        {
            List<TypeSortie> lesTypeSorties = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                lesTypeSorties = ctx.TypeSorties.ToList();
            };
            return lesTypeSorties;
        }

        public static void Add(TypeSortie Tsortie)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.TypeSorties.Add(Tsortie);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                TypeSortie Tsortie = GetById(id, ctx);
                ctx.TypeSorties.Remove(Tsortie);
                ctx.SaveChanges();
            }
        }

        public static TypeSortie GetById(int id, ApplicationDbContext ctx = null)
        {
            TypeSortie ts = null;
            if (ctx != null)
            {
                ts = ctx.TypeSorties.Where(t => t.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    ts = ctx.TypeSorties.Where(t => t.Id == id).FirstOrDefault();
                }
            }
            return ts;
        }

        public static void Edit(TypeSortie tpSorti)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                TypeSortie ts = GetById(tpSorti.Id);
                if (ts != null)
                {
                    ts.Nom = tpSorti.Nom;
                    ctx.SaveChanges();
                }
                ctx.SaveChanges();
            }
        }
    }
}
