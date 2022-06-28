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

    public class SubcategoryService : ISubcategoryService
    {
        private readonly ApplicationDbContext dbContext;

        public SubcategoryService(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }
        public async Task<IList<SubcategoryViewModel>> GetAll()
        {
           var subcategories = await dbContext.Subcategory.ToListAsync();

            return subcategories.Select(sc =>
            new SubcategoryViewModel()
            {
                Id = sc.Id,
                Name = sc.Name,
                CategoryName = sc.Category.Name
            }).ToList();
        }

        public async Task AddSubcategory(int selectedCategoryId, string newSubcategoryName)
        {
            var subcategory = new Subcategory()
            {
                Name = newSubcategoryName,
                CategoryId = selectedCategoryId
                
            };
            try
            {
                await dbContext.Subcategory.AddAsync(subcategory);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<SubcategoryViewModel>> GetAllByCategoryId(int categoryId)
        {
            var subcategories = await dbContext.Subcategory
                .Include(sb => sb.Category)
                .Where(s => s.CategoryId == categoryId)
                .ToListAsync();

            return subcategories.Select(sc =>
            new SubcategoryViewModel()
            {
                Id = sc.Id,
                Name = sc.Name,
                CategoryName = sc.Category.Name
            }).ToList();
        }
    }
}
