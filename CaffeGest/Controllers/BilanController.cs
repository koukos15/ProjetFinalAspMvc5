using CaffeGest.Models;
using CaffeGest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaffeGest.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BilanController : Controller
    {
        // GET: Bilan
        public ActionResult Index()
        {
            string dateDebut = this.Request.Form.Get("dateDebut");
            string dateFin = this.Request.Form.Get("dateFin");
            double montantAchat= 0;
            double montantDepense = 0;
            double? montantVente = 0;
            double benefice = 0 ;
            if (dateDebut != null && dateFin != null)
            {
                DateTime dateDebut1 = DateTime.Parse(this.Request.Form.Get("dateDebut"));
                DateTime dateFin1 = DateTime.Parse(this.Request.Form.Get("dateFin"));

                List<Achat> mesAchats = AchatManager.GetAll(dateDebut1, dateFin1);
                List<Depense> depenses = DepenseManager.GetAll(dateDebut1, dateFin1);
                List<Sortie> sorties = SortieManager.GetAll(dateDebut1, dateFin1,"vente");

                foreach(Achat a in mesAchats)
                {
                    montantAchat += a.Montant;
                }
                foreach (Depense a in depenses)
                {
                    montantDepense += a.Montant;
                }
                foreach (Sortie a in sorties)
                {
                    montantVente += a.Montant;
                }

                benefice = Convert.ToDouble(montantVente)  - montantAchat - montantDepense;

                ViewBag.MontantD = montantDepense;
                ViewBag.MontantV = montantVente;
                ViewBag.MontantA = montantAchat;
                ViewBag.Bene = benefice;
                return View();
            }
            return View();
        }
    }
}