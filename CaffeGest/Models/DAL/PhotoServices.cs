using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models.DAL
{
    public class PhotoServices
    {

        public static List<Photo> GetAllPhotos(int produitId)
        {
            List<Photo> list = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                list = ctx.Photos.Where(m => m.ProduitId == produitId).ToList();
            }
            return list;
        }

        public static Photo FindById(int id, ApplicationDbContext db = null)
        {
            Photo retour = null;
            if (db != null)
            {
                retour = db.Photos.Where(p => p.Id == id).FirstOrDefault();
            }
            else
            {
                using (db = new ApplicationDbContext())
                {
                    retour = db.Photos.Where(p => p.Id == id).FirstOrDefault();
                }
            }

            return retour;
        }

        public static void Add(Photo photo)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Photos.Add(photo);
                db.SaveChanges();
            }
        }

        public static void Save(Photo photo)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (photo != null)
                {
                    Photo dbPhoto = FindById(photo.Id, db);
                    if (dbPhoto != null)
                    {
                        dbPhoto.ImgPath = photo.ImgPath;
                        dbPhoto.EstPrincipal = photo.EstPrincipal;
                        dbPhoto.ProduitId = photo.ProduitId;
                        db.SaveChanges();
                    }
                }
            }
        }

        public static void Delete(int id)
        {
            Photo photo = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                photo = FindById(id, db);
                if (photo != null)
                {
                    db.Photos.Remove(photo);
                    db.SaveChanges();
                }
            }
        }
    }
}