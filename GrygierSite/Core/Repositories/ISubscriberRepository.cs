using GrygierSite.Core.Models;

namespace GrygierSite.Core.Repositories
{
    public interface ISubscriberRepository
    {
        void Add(Subscriber subscriber);
        void Remove(Subscriber subscriber);
        void Remove(int subscriberId);
        bool Contains(string email);
    }
}