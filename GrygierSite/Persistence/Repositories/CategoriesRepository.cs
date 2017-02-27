using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GrygierSite.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string GetCategoryName(int categoryId)
        {
            return _context.Categories.Single(c => c.Id == categoryId).Name;
        }

        public IEnumerable<Category> GetLastChildCategories()
        {
            return _context.Categories.Where(c => c.Id != 2).ToList();
        }
    }
}