using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaffeGest.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public bool EstPrincipal { get; set; }

        public int ProduitId { get; set; }

        public Produit produit { get; set; }
    }
}