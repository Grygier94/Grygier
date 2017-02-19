using System.Collections.Generic;
using GrygierSite.Core.Models;

namespace GrygierSite.Core.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> GetLastChildCategories();
    }
}