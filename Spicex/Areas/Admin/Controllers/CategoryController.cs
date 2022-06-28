using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spicex.Models;
using Spicex.Services.Descriptions;

namespace Spicex.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAll();
            return View(categories);
        }
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            if (!ModelState.IsValid) return View(category);
            await categoryService.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }
}