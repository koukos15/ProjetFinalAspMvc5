using CaffeGest.Models;
using CaffeGest.Models.DAL;
using CaffeGest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Controllers
{
    [Authorize]
    public class SortieController : Controller
    {
        // GET: Sortie
        public ActionResult Index()
        { 
            string dateDebut = this.Request.Form.Get("dateDebut");
            string dateFin = this.Request.Form.Get("dateFin");
            string typeSortie = this.Request.Form.Get("typeSortie");

            //list de sortie
            ViewBag.TypeSorties = TypeSortieManager.GetListItemNom();


            if (dateDebut != null && dateFin != null && typeSortie != null)
            {
                DateTime dateDebut1 = DateTime.Parse(this.Request.Form.Get("dateDebut"));
                DateTime dateFin1 = DateTime.Parse(this.Request.Form.Get("dateFin"));

                List<Sortie> mesSorties = SortieManager.GetAll(dateDebut1, dateFin1, typeSortie);
                return View(mesSorties);
            }

            return View();

        }

        public ActionResult Add()
        {
            ViewBag.Clients = ClientServices.GetListItem(-1);
            ViewBag.Produits = ProduitManager.GetListItem(-1);
            ViewBag.TypeSorties = TypeSortieManager.GetListItem(-1);
            return View();
        }

        [HttpPost]
        public ActionResult Add(Sortie sortie)
        {
            if (this.ModelState.IsValid)
            {
                SortieManager.Add(sortie);

                TempData["msg"] = "la sortie du produit a ete ajoute avec succces";
                return RedirectToAction("index");
            }

            ViewBag.Clients = ClientServices.GetListItem(-1);
            ViewBag.Produits = ProduitManager.GetListItem(-1);
            ViewBag.TypeSorties = TypeSortieManager.GetListItem(-1);
            return View(sortie);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Sortie sortie = SortieManager.GetById(id.Value);

                if (sortie != null)
                {
                    ViewBag.Clients = ClientServices.GetListItem(sortie.Id);
                    ViewBag.Produits = ProduitManager.GetListItem(sortie.Id);
                    ViewBag.TypeSorties = TypeSortieManager.GetListItem(sortie.Id);

                    return View(sortie);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Sortie sortie)
        {
            if (this.ModelState.IsValid)
            {

                SortieManager.Edit(sortie);
                TempData.Add("msg", "la sortie du produit a ete modifie avec succces");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            SortieManager.delete(id);
            TempData.Add("msg", "la sortie a ete supprime avec succces");
            return RedirectToAction("Index");
        }

        public ActionResult PartialView(int id)
        {
            Produit produit = ProduitsServices.GetById(id);
            if (produit != null)
            {
                ViewBag.Pu = produit.PU;
            }

            return View();
        }
    }
}