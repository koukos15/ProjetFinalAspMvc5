using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class UserServices
    {
        public static List<User> GetAllUsers()
        {
            List<User> lesUsers = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                lesUsers = ctx.mesUsers.ToList();
            }
            return lesUsers;
        }

        public static void Add(User user)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.mesUsers.Add(user);
                ctx.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            User user = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                user = GetById(id);
                ctx.mesUsers.Remove(user);
                ctx.SaveChanges();
            }
        }
        public static User GetById(int id, ApplicationDbContext ctx = null)
        {
            User u = null;
            if (ctx != null)
            {
                u = ctx.mesUsers.Where(us => us.Id == id).FirstOrDefault();
            }else
            {
                using (ctx = new ApplicationDbContext())
                {
                    u = ctx.mesUsers.Where(us => us.Id == id).FirstOrDefault();
                }
            }
            return u;
        }
    }

}