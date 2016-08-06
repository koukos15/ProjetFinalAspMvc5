using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaffeGest.Models
{
    public class Entree
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateEntree { get; set; }

        public int QteEntree { get; set; }
        public double Montant { get; set; }

        //cle etrangere
        public int ProduitId { get; set; }
        public int FournisseurId { get; set; }

        //propriete de navigation
        public virtual Produit Produit { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
    }
}