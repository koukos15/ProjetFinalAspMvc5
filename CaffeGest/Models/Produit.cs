using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaffeGest.Models
{
    public class Produit
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "entre un nom entre 3 et 50 characteres")]
        public string Nom { get; set; }
        public double PU { get; set; }
        public int QuantiteStock { get; set; }

        //cle etrangere
        public int CategorieId { get; set; }

        //propriete de navigation
        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<Entree> Entrees { get; set; }
        public virtual ICollection<Sortie> Sorties { get; set; }
        public virtual ICollection<Fournisseur> Fournisseurs { get; set; }
    }
}