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
    public class AchatController : Controller
    {

        // GET: Achat
        public ActionResult Index()
        {
            string dateDebut = this.Request.Form.Get("dateDebut");
            string dateFin = this.Request.Form.Get("dateFin");

            if (dateDebut != null && dateFin != null)
            {
                DateTime dateDebut1 = DateTime.Parse(this.Request.Form.Get("dateDebut"));
                DateTime dateFin1 = DateTime.Parse(this.Request.Form.Get("dateFin"));

                List<Achat> mesAchats = AchatManager.GetAll(dateDebut1, dateFin1);
                return View(mesAchats);
            }

            return View();
           
        }

        public ActionResult Add()
        {
            ViewBag.Fournisseurs = FournisseurManager.GetListItem(-1);
            ViewBag.Produits = ProduitManager.GetListItem(-1);
            return View();
        }

        [HttpPost]
        public ActionResult Add(Achat unAchat)
        {
            if (this.ModelState.IsValid)
            {
                AchatManager.Add(unAchat);

                TempData["msg"] = "l'achat a ete ajoute avec succces";
                return RedirectToAction("index");
            }

            ViewBag.Fournisseurs = FournisseurManager.GetListItem(-1);
            ViewBag.Produits = ProduitManager.GetListItem(-1);
            return View(unAchat);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Achat unAchat = AchatManager.GetById(id.Value);

                if (unAchat != null)
                {
                    ViewBag.Fournisseurs = FournisseurManager.GetListItem(unAchat.Id);
                    //ViewData.("Produits") = ProduitManager.GetListItem(unAchat.Id);
                    ViewData["Produits"] = ProduitManager.GetListItem(unAchat.Id);

                    return View(unAchat);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Achat unAchat)
        {
            unAchat.Produit.Id = 1;
            if (this.ModelState.IsValid)
            {
               
                AchatManager.Edit(unAchat);
                TempData.Add("msg", "l'achat a ete modifie avec succces");
                return RedirectToAction("Index");
            }

            return View(unAchat);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            AchatManager.delete(id);
            TempData.Add("msg", "l'achat a ete supprime avec succces");
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