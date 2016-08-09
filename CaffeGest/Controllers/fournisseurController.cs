using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Controllers
{
    [Authorize]
    public class FournisseurController : Controller
    {
        // GET: fournisseur
        public ActionResult Index()
        {
            return View();
        }
    }
}