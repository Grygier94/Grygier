using GrygierSite.Core;
using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;
using GrygierSite.Persistence.Repositories;

namespace GrygierSite.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IProductRepository Products { get; }
        public ICategoriesRepository Categories { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoriesRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}