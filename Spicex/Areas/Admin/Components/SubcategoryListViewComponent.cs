using Microsoft.AspNetCore.Mvc;
using Spicex.Services.Descriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spicex.Areas.Admin.Components
{
    public class SubcategoryListViewComponent : ViewComponent
    {
        private readonly ISubcategoryService subcategoryService;

        public SubcategoryListViewComponent(ISubcategoryService subcategoryService)
        {
            this.subcategoryService = subcategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            var subCategories = await subcategoryService.GetAllByCategoryId(categoryId);
            return View(subCategories);
        }
    }
}
