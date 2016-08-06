﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaffeGest.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "entre un nom entre 3 et 50 characteres")]
        public string Nom { get; set; }

        [Required]
        public string Tel { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Adresse { get; set; }

        //cle etrangere
        public int TypeClientId { get; set; }

        //propriete de navigation
        public virtual TypeClient TypeClient { get; set; }
    }
}