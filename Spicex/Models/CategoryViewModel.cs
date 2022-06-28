using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spicex.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category name")]
        [Required]
        public string Name { get; set; }


        public IList<SubcategoryViewModel> Subcategories { get; set; }

        public bool HasSubcategories => Subcategories != null && Subcategories.Any();
    }
}
