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
    public class FournisseurController : Controller
    {
        // GET: fournisseur
        public ActionResult ListFournisseurs()
        {
            List<Fournisseur> lesFournisseurs = FournisseurServices.GetAllFournisseurs();
            return View(lesFournisseurs);
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {

                Fournisseur pers = FournisseurServices.GetById(id.Value);

                if (pers != null)
                {
                    return View(pers);
                }
            }
            return RedirectToAction("ListFournisseurs");
        }

        public ActionResult Add()
        {
            IEnumerable<SelectListItem> ListProduits = ProduitsServices.GetAllProduits().Select(Lc => new SelectListItem
            {
                
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });
            this.ViewBag.Prods = ListProduits;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Fournisseur fournisseur)
        {

            if (this.ModelState.IsValid)
            {
                FournisseurServices.Add(fournisseur);
                return this.RedirectToAction("ListFournisseurs");
            }
            IEnumerable<SelectListItem> ListProduits = ProduitsServices.GetAllProduits().Select(Lc => new SelectListItem
            {
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });
            this.ViewBag.Prods = ListProduits;
            return View(fournisseur);
        }

        public ActionResult Delete(int id)
        {
            FournisseurServices.Delete(id);
            return this.RedirectToAction("ListFournisseurs");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Fournisseur f = FournisseurServices.GetById(id.Value);
                if (f != null)
                {
                    IEnumerable<SelectListItem> ListProduits = ProduitsServices.GetAllProduits().Select(Lc => new SelectListItem
                    {
                        Text = Lc.Nom,
                        Value = Lc.Id.ToString()
                    });
                    this.ViewBag.Prods = ListProduits;
                    return View(f);
                }
            }
            return RedirectToAction("ListFournisseurs");
        }

        [HttpPost]
        public ActionResult Edit(Fournisseur fournisseur)
        {
            if (this.ModelState.IsValid)
            {
                FournisseurServices.Edit(fournisseur);
                return RedirectToAction("ListFournisseurs",
                   new { id = fournisseur.Id });
            }
            IEnumerable<SelectListItem> ListProduits = ProduitsServices.GetAllProduits().Select(Lc => new SelectListItem
            {
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });
            this.ViewBag.Prods = ListProduits;
            return View(fournisseur);
        }
    }
}