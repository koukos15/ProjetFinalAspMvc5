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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult ListClients()
        {
            List<Client> ListClients = ClientServices.GetAllClient();
            this.ViewBag.CLients = ListClients;
            return View(ListClients);
        }

        public ActionResult Add()
        {

            IEnumerable<SelectListItem> ListTypesClients = TypeClientService.GetAllTypeClient().Select(Ltc => new SelectListItem
            {
                Text = Ltc.Nom,
                Value = Ltc.Id.ToString()
            });

            this.ViewBag.TypesClients = ListTypesClients;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Client client)
        {
            if (this.ModelState.IsValid)
            {
                ClientServices.AddClient(client);
                return this.RedirectToAction("ListClients");
            }
            IEnumerable<SelectListItem> ListTypesClients = TypeClientService.GetAllTypeClient().Select(Ltc => new SelectListItem
            {
                Text = Ltc.Nom,
                Value = Ltc.Id.ToString()
            });

            this.ViewBag.TypesClients = ListTypesClients;
            return View(client);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ClientServices.Delete(id);
            return this.RedirectToAction("ListClients");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Client c = ClientServices.GetById(id.Value);
                if (c != null)
                {
                    IEnumerable<SelectListItem> ListTypesClients = TypeClientService.GetAllTypeClient().Select(Ltc => new SelectListItem
                    {
                        Text = Ltc.Nom,
                        Value = Ltc.Id.ToString()
                    });

                    this.ViewBag.TypesClients = ListTypesClients;
                    return View(c);
                }
            }
            return RedirectToAction("ListProduits");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Client client)
        {
            if (this.ModelState.IsValid)
            {
                ClientServices.Edit(client);
                return RedirectToAction("ListClients",
                   new { id = client.Id });
            }
            IEnumerable<SelectListItem> ListTypesClients = TypeClientService.GetAllTypeClient().Select(Ltc => new SelectListItem
            {
                Text = Ltc.Nom,
                Value = Ltc.Id.ToString()
            });

            this.ViewBag.TypesClients = ListTypesClients;
            return View(client);
        }
    }
}