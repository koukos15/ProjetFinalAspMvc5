using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaffeGest.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "entre un nom entre 3 et 50 characteres")]
        public string Nom { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
      
        public string ApplicationUserId { get; set; }
    }
}