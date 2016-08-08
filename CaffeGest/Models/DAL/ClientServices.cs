using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class ClientServices
    {
        public static List<Client> GetAllClient()
        {
            List<Client> LesClients = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                LesClients = ctx.Clients.Include("TypeClient").ToList();
            }
            return LesClients;
        }

        public static void AddClient(Client client)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(client);
                ctx.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Client client = GetById(id, ctx);
                ctx.Clients.Remove(client);
                ctx.SaveChanges();
            }
        }

        public static Client GetById(int id, ApplicationDbContext ctx = null)
        {
            Client c = null;
            if (ctx != null)
            {
                c = ctx.Clients.Include("TypeClient").Where(cl => cl.Id == id).FirstOrDefault();
            }
            else
            {
                using (ctx = new ApplicationDbContext())
                {
                    c = ctx.Clients.Include("TypeClient").Where(cl => cl.Id == id).FirstOrDefault();
                }
            }
            return c;
        }

        public static void Edit(Client client)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Client c = GetById(client.Id, ctx);
                if (c != null)
                {
                    c.Nom = client.Nom;
                    c.Tel = client.Tel;
                    c.Email = client.Email;
                    c.Adresse = client.Adresse;
                    ctx.SaveChanges();
                }
                ctx.SaveChanges();
            }
        }
    }
}