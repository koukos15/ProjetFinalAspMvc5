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
    public class TypeClientController : Controller
    {
        // GET: TypeClient
        public ActionResult ListTypeClients()
        {
            List<TypeClient> ListTypeClients = TypeClientService.GetAllTypeClient();
            this.ViewBag.TypeClients = ListTypeClients;
            return View(ListTypeClients);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TypeClient tp)
        {
            if (this.ModelState.IsValid)
            {
                TypeClientService.Add(tp);

                return this.RedirectToAction("ListTypeClients");
            }
            return View(tp);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            TypeClientService.Delete(id);
            return this.RedirectToAction("ListTypeClients");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                TypeClient tpClient =  TypeClientService.GetById(id.Value);
                if (tpClient != null)
                {
                    return View(tpClient);
                }
            }
            return RedirectToAction("ListTypeClients");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(TypeClient tp)
        {
            if (this.ModelState.IsValid)
            {
                TypeClientService.Edit(tp);
                return RedirectToAction("ListTypeClients",
                   new { id = tp.Id });
            }
            return View(tp);
        }
    }
}