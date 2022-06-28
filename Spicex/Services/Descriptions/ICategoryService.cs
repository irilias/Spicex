using Spicex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spicex.Services.Descriptions
{
    public interface ICategoryService
    {
         Task<IList<CategoryViewModel>> GetAll();

        Task AddCategory(CategoryViewModel categoryViewModel);

        Task<IList<CategoryViewModel>> GetAllWithSubcategories();
    }
}
