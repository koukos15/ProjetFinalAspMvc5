using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Models.DAL
{
    public class ProduitManager
    {
        public static List<Produit> GetAll()
        {
            List<Produit> allProduits = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                allProduits = ctx.Produits.OrderBy(p => p.Id).ToList();
            }
            return allProduits;
        }

        public static IEnumerable<SelectListItem> GetListItem(int id)
        {
            IEnumerable<SelectListItem> maList = GetAll().Select(
                p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Nom,
                    Selected = (id == p.Id)
                }
            );
            return maList;
        }
    }
}