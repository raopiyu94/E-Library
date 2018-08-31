using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class Customer
    {
        [Required]
        [Key]
        public string userName { get; set; }

        public string Password { get; set; }
    }
}