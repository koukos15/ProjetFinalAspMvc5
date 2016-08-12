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
    public class TypeSortieController : Controller
    {

        // GET: TypeClient
        public ActionResult ListTypeSorties()
        {
            List<TypeSortie> ListTSorties = TypeSortieServices.GetAllTypeSorties();

            return View(ListTSorties);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TypeSortie ts)
        {
            if (this.ModelState.IsValid)
            {
                TypeSortieServices.Add(ts);

                return this.RedirectToAction("ListTypeSorties");
            }
            return View(ts);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            TypeSortieServices.Delete(id);
            return this.RedirectToAction("ListTypeSorties");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                TypeSortie ts = TypeSortieServices.GetById(id.Value);
                if (ts != null)
                {
                    return View(ts);
                }
            }
            return RedirectToAction("ListTypeSorties");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(TypeSortie ts)
        {
            if (this.ModelState.IsValid)
            {
                TypeSortieServices.Edit(ts);
                return RedirectToAction("ListTypeSorties",
                   new { id = ts.Id });
            }
            return View(ts);
        }
    }
}
