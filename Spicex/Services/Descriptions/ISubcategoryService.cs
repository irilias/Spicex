using Spicex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spicex.Services.Descriptions
{
    public interface ISubcategoryService
    {
         Task<IList<SubcategoryViewModel>> GetAll();

        Task AddSubcategory(int selectedCategoryId, string newSubcategoryName);


        Task<IList<SubcategoryViewModel>> GetAllByCategoryId(int categoryId);
    }
}
