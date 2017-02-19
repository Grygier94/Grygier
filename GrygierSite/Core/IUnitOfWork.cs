using GrygierSite.Core.Repositories;

namespace GrygierSite.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoriesRepository Categories { get; }

        void Complete();
    }
}