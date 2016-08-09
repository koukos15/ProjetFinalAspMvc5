using CaffeGest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaffeGest.Services;

namespace CaffeGest.Controllers
{
    [Authorize]
    public class ProduitController : Controller
    {
        // GET: Produit
        public ActionResult ListProduits()
        {
            List<Produit> ListProduits = ProduitsServices.GetAllProduits();
            this.ViewBag.Produits = ListProduits;
            return View(ListProduits);
        }

        public ActionResult Add()
        {

            IEnumerable<SelectListItem> ListCategories = CategoriesServices.GetAllCategories().Select(Lc => new SelectListItem
            {
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });

            this.ViewBag.Cats = ListCategories;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Produit produit)
        {
            if (this.ModelState.IsValid)
            {
                ProduitsServices.AddProduit(produit);
                return this.RedirectToAction("ListProduits");
            }
            IEnumerable<SelectListItem> ListCategories = CategoriesServices.GetAllCategories().Select(Lc => new SelectListItem
            {
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });

            this.ViewBag.Cats = ListCategories;
            return View(produit);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ProduitsServices.Delete(id);
            return this.RedirectToAction("ListProduits");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {

            if (id != null)
            {
                Produit p = ProduitsServices.GetById(id.Value);
                if (p != null)
                {
                    IEnumerable<SelectListItem> ListCategories = CategoriesServices.GetAllCategories().Select(Lc => new SelectListItem
                    {
                        Text = Lc.Nom,
                        Value = Lc.Id.ToString()
                    });

                    this.ViewBag.Cats = ListCategories;
                    return View(p);
                }
            }
            return RedirectToAction("ListProduits");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Produit produit)
        {
            if (this.ModelState.IsValid)
            {
                ProduitsServices.Edit(produit);
                return RedirectToAction("ListProduits",
                   new { id = produit.Id });
            }
            IEnumerable<SelectListItem> ListCategories = CategoriesServices.GetAllCategories().Select(Lc => new SelectListItem
            {
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });
            this.ViewBag.Cats = ListCategories;
            return View(produit);
        }
    }
}