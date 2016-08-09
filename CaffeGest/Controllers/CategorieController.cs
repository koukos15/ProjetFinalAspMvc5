using CaffeGest.Models;
using CaffeGest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Controllers
{
    [Authorize]
    public class CategorieController : Controller
    {
        // GET: Categorie
        public ActionResult ListCategories()
        {
            List<Categorie> ListCategories = CategoriesServices.GetAllCategories();
            this.ViewBag.Categories = ListCategories;
            return View(ListCategories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Categorie cat)
        {
            if (this.ModelState.IsValid)
            {
                CategoriesServices.AddProduit(cat);
                return this.RedirectToAction("ListCategories");
            }
            return View(cat);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            CategoriesServices.Delete(id);
            return this.RedirectToAction("ListCategories");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Categorie cat = CategoriesServices.GetById(id.Value);
                if (cat != null)
                {                 
                    return View(cat);
                }
            }
            return RedirectToAction("ListCategories");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Categorie Categorie)
        {
            if (this.ModelState.IsValid)
            {
                CategoriesServices.Edit(Categorie);
                return RedirectToAction("ListCategories",
                   new { id = Categorie.Id });
            }
            return View(Categorie);
        }
    }
}