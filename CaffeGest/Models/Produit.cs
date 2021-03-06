﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Poids { get; set; }
        public string Img { get; set; }

        //cle etrangere
        public Nullable<int> CategorieId { get; set; }

        [NotMapped]
        public List<int> FournisseursId { get; set; }

        //propriete de navigation
        public virtual Categorie Categorie { get; set; }
        public virtual ICollection<Achat> Achats { get; set; }
        public virtual ICollection<Sortie> Sorties { get; set; }
        public virtual ICollection<Fournisseur> Fournisseurs { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

        //public HttpPostedFileBase ProduitPicture { get; set; }

    }
}