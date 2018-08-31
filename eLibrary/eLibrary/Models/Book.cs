using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary.Models
{
    public class Book
    {
        [Required]
        [Key]
        public string bookName { get; set; }

        public string bookGenre { get; set; }

        public float bookCost { get; set; }
    }
}