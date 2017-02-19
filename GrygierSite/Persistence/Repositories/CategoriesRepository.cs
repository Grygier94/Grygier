using System.Collections.Generic;
using System.Linq;
using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;

namespace GrygierSite.Persistence.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetLastChildCategories()
        {
            return _context.Categories.Where(c => c.Id != 2).ToList();
        }
    }
}