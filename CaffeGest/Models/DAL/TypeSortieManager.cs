using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Models.DAL
{
    public class TypeSortieManager
    {
        public static List<TypeSortie> GetAll()
        {
            List<TypeSortie> types = null;
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                types = ctx.TypeSorties.OrderBy(t => t.Id).ToList();
            }
            return types;
        }

        public static IEnumerable<SelectListItem> GetListItem(int id)
        {
            IEnumerable<SelectListItem> maList = GetAll().Select(
                t => new SelectListItem
                {
                    Value = t.Id.ToString(),
                    Text = t.Id.ToString(),
                    Selected = (id == t.Id)
                }
            );
            return maList;
        }

        public static IEnumerable<SelectListItem> GetListItemNom()
        {
            IEnumerable<SelectListItem> maList = GetAll().Select(
                t => new SelectListItem
                {
                    Value = t.Nom,
                    Text = t.Nom,
                }
            );
            return maList;
        }
    }
}