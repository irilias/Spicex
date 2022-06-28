using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Spicex.Models;
using Spicex.Services.Descriptions;

namespace Spicex.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubcategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISubcategoryService subCategoryService;

        public SubcategoryController(ICategoryService categoryService, ISubcategoryService subCategoryService)
        {
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllWithSubcategories();
            TempData[nameof(CategoryViewModel)] = JsonConvert.SerializeObject(categories);
            return View(categories);

        }
        public IActionResult GetSubcategoriesList(int categoryId)
        {
            return ViewComponent("SubcategoryList", new { categoryId = categoryId });
        }
        public async Task<IActionResult> Create()
        {
            var categories = TempData[nameof(CategoryViewModel)];
            categories = !(categories is null) ? JsonConvert.DeserializeObject<IList<CategoryViewModel>>(categories.ToString())
                             : await categoryService.GetAllWithSubcategories();
            return View(categories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int selectedCategoryId, string newSubcategoryName)
        {
            if (!ModelState.IsValid || String.IsNullOrEmpty(newSubcategoryName)) 
            {
                ViewData["Error"] = "An Error has occured while creating the sub-category.";
                return View();
            }
            await subCategoryService.AddSubcategory(selectedCategoryId, newSubcategoryName) ;
            return RedirectToAction(nameof(Index));
        }
    }
}