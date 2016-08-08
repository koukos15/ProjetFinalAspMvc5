using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Models.DAL
{
    public class FournisseurManager
    {
        public static List<Fournisseur> GetAll()
        {
            List<Fournisseur> allFournisseurs = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                allFournisseurs = ctx.Fournissseurs.OrderBy(f => f.Id).ToList();
            }
            return allFournisseurs;
        }

        public static IEnumerable<SelectListItem> GetListItem(int id)
        {
            IEnumerable<SelectListItem> maList = GetAll().Select(
                f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.Nom,
                    Selected = (id == f.Id)
                }
            );
            return maList;
        }
    }
}