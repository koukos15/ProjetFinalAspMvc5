using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen_Final_Joel.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjouterRole(string userId, string rolename)
        {
            return RedirectToAction("AddUserToRole", controllerName: "Account",
                routeValues: new { userId = userId, rolename = rolename }
                );
        }
    }
}