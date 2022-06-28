using Microsoft.EntityFrameworkCore;
using Spicex.Data;
using Spicex.Data.Models;
using Spicex.Models;
using Spicex.Services.Descriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spicex.Services
{

    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryService(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public async Task<IList<CategoryViewModel>> GetAll()
        {
           var categories = await dbContext.Category.ToListAsync();

            return categories.Select(c =>
            new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }

        public async Task<IList<CategoryViewModel>> GetAllWithSubcategories()
        {
            var categories = await dbContext.Category.Include(c => c.Subcategories).ToListAsync();
            return categories.Select(c =>
            new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Subcategories = c.Subcategories.Select(sc => 
                new SubcategoryViewModel()
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryName = c.Name
                }).ToList()
            }).ToList();
        }

        public async Task AddCategory(CategoryViewModel categoryViewModel)
        {
            var category = new Category()
            {
                Name = categoryViewModel.Name
            };
            try
            {
                await dbContext.AddAsync(category);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
