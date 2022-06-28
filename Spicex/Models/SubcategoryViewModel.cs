using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spicex.Models
{
    public class SubcategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Subcategory name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Category name")]
        [Required]
        public string CategoryName { get; set; }

    }
}
