using System.Collections.Generic;
using GrygierSite.Core.Models;

namespace GrygierSite.Core.Repositories
{
    public interface ICategoriesRepository
    {
        string GetCategoryName(int categoryId);
        IEnumerable<Category> GetLastChildCategories();
    }
}