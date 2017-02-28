using GrygierSite.Core.Repositories;

namespace GrygierSite.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoriesRepository Categories { get; }
        ITagsRepository Tags { get; }

        void Complete();
    }
}