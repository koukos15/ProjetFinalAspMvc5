using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaffeGest.Models
{
    public class Sortie
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSortie { get; set; }

        public int QteSortie { get; set; }
        public double? Montant { get; set; }

        //cle etrangere
        public int TypeSortieId { get; set; }
        public int ProduitId { get; set; }
        public int? ClientId { get; set; }

        //propriete de navigation
        public virtual TypeSortie TypeSortie { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual Client Client { get; set; }
    }
}