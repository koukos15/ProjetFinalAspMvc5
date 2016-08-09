using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class TypeClientService
    {
        public static List<TypeClient> GetAllTypeClient()
        {
            List<TypeClient> lesClients = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                lesClients = ctx.TypeClients.ToList();
            };
            return lesClients;
        }

        public static void Add(TypeClient Tclient)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.TypeClients.Add(Tclient);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                TypeClient Tclient = GetById(id, ctx);
                ctx.TypeClients.Remove(Tclient);
                ctx.SaveChanges();
            }
        }

        public static TypeClient GetById(int id, ApplicationDbContext ctx = null)
        {
            TypeClient tc = null;
            if (ctx != null)
            {
                tc = ctx.TypeClients.Where(t => t.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    tc = ctx.TypeClients.Where(t => t.Id == id).FirstOrDefault();
                }
            }
            return tc;
        }

        public static void Edit(TypeClient tpClient)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                TypeClient tp = GetById(tpClient.Id);
                if(tp != null)
                {
                    tp.Nom = tpClient.Nom;
                    ctx.SaveChanges();
                }
                ctx.SaveChanges();
            }
        }
    }
}