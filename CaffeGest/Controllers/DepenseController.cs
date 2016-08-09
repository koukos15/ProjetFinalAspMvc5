using CaffeGest.Models;
using CaffeGest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Controllers
{
    [Authorize]
    public class DepenseController : Controller
    {
        // GET: Depense
        public ActionResult Index()
        {
            string dateDebut = this.Request.Form.Get("dateDebut");
            string dateFin = this.Request.Form.Get("dateFin");

            if (dateDebut != null && dateFin != null)
            {
                DateTime dateDebut1 = DateTime.Parse(this.Request.Form.Get("dateDebut"));
                DateTime dateFin1 = DateTime.Parse(this.Request.Form.Get("dateFin"));

                List<Depense> depenses = DepenseManager.GetAll(dateDebut1, dateFin1);
                return View(depenses);
            }

            return View();

        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Depense depense)
        {
            if (this.ModelState.IsValid)
            {
               
                DepenseManager.Add(depense);

                TempData["msg"] = "depense ajoute avec succces";
                return RedirectToAction("index");
            }

            return View(depense);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Depense depense = DepenseManager.GetById(id.Value);

                if (depense != null)
                {                 
                    return View(depense);
                }

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Depense depense)
        {
            if (this.ModelState.IsValid)
            {

                DepenseManager.Edit(depense);
                TempData.Add("msg", "depense modifie avec succces");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            DepenseManager.delete(id);
            TempData.Add("msg", "depense supprimee avec succces");
            return RedirectToAction("Index");
        }
    }
}