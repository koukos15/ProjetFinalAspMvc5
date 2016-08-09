using CaffeGest.Models;
using CaffeGest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Controllers
{
    public class AchatController : Controller
    {

        // GET: Achat
        public ActionResult Index()
        {
            //Get(dateDebut), dateDebut repersente le nom de l'attribut name de mon input 
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
                //Produit unProduit = ProduitManager.GetById(unAchat.ProduitId);
                //unProduit.QuantiteStock += unAchat.QteAchetee;
                AchatManager.Add(unAchat);

                ViewBag.ListProduits = ProduitManager.GetAll();
                TempData["msg"] = "l'achat a ete ajoute avec succces";
                return RedirectToAction("index");
            }

            ViewBag.Fournisseurs = FournisseurManager.GetListItem(-1);
            ViewBag.Produits = ProduitManager.GetListItem(-1);
            return View(unAchat);
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Achat unAchat = AchatManager.GetById(id.Value);

                if (unAchat != null)
                {
                    ViewBag.Fournisseurs = FournisseurManager.GetListItem(unAchat.Id);
                    ViewBag.Produits = ProduitManager.GetListItem(unAchat.Id);

                    return View(unAchat);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Achat unAchat)
        {
            if (this.ModelState.IsValid)
            {
               
                AchatManager.Edit(unAchat);
                TempData.Add("msg", "l'achat a ete modifie avec succces");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            AchatManager.delete(id);
            TempData.Add("msg", "l'achat a ete supprime avec succces");
            return RedirectToAction("Index");
        }
    }
}