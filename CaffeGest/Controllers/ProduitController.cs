using CaffeGest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using CaffeGest.Services;
using CaffeGest.Models.DAL;

namespace CaffeGest.Controllers
{
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

            List<Fournisseur> LesFournisseurs = FournisseurServices.GetAllFournisseurs().ToList(); 
            
          //  List<Photo> lesTofs = PhotoServices.         
            this.ViewBag.Fournisseurs = LesFournisseurs;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Produit produit)
        {
            if (this.ModelState.IsValid)
            {

                List<int> ids = this.Request.Form.GetValues("frs").Select(h => int.Parse(h)).ToList();
                produit.FournisseursId = ids;

                ProduitsServices.AddProduit(produit);
                return this.RedirectToAction("ListProduits");
            }
            IEnumerable<SelectListItem> ListCategories = CategoriesServices.GetAllCategories().Select(Lc => new SelectListItem
            {
                Text = Lc.Nom,
                Value = Lc.Id.ToString()
            });

            this.ViewBag.Cats = ListCategories;

            List<Fournisseur> LesFournisseurs = FournisseurServices.GetAllFournisseurs().ToList();
            this.ViewBag.Fournisseurs = LesFournisseurs;

            return View(produit);
        }

        public ActionResult Delete(int id)
        {
            ProduitsServices.Delete(id);
            return this.RedirectToAction("ListProduits");
        }

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

                    List<Fournisseur> LesFournisseurs = FournisseurServices.GetAllFournisseurs().ToList();
                    this.ViewBag.Fournisseurs = LesFournisseurs;

                    return View(p);
                }
            }
            return RedirectToAction("ListProduits");
        }

        [HttpPost]
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

            List<Fournisseur> LesFournisseurs = FournisseurServices.GetAllFournisseurs().ToList();
            this.ViewBag.Fournisseurs = LesFournisseurs;
            return View(produit);
        }

        public ActionResult ProduitPhotos(Produit produit)
        {
            produit.Photos = PhotoServices.GetAllPhotos(produit.Id);
            List<Photo> lesPhotos = PhotoServices.GetAllPhotos(produit.Id);
            this.ViewBag.Photos = lesPhotos;
            return View(produit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //    [Authorize(Roles = "SuperAdmin, Admin")]
        public ActionResult ProduitPhotos(Produit produit, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                try
                {
                    bool principal = bool.TryParse(Request.Form["principal"], out principal);
                    Photo photo = new Photo
                    {
                        ImgPath = System.IO.Path.GetFileName(upload.FileName),
                        ProduitId = produit.Id,
                        EstPrincipal = principal
                    };
                    if (produit.Photos == null)
                    {
                        produit.Photos = new List<Photo>();
                    }
                    produit.Photos.Add(photo);
                    upload.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Image"), System.IO.Path.GetFileName(photo.ImgPath)));
                    PhotoServices.Add(photo);
                    ViewBag.Message = "Fichier envoyé avec succès";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "Vous n'avez pas spécifié un fichier.";
            }
            return RedirectToAction("ListProduits",new { Id = produit.Id });
        }

        public ActionResult Save(Photo photo) {

            PhotoServices.Add(photo);
            return RedirectToAction("ListProduits");
        }

        public ActionResult DeletePhoto(int id)
        {
            PhotoServices.Delete(id);
            return RedirectToAction("ListProduits");
        }
    }
}