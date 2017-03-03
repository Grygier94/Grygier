using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;
using System.Linq;

namespace GrygierSite.Persistence.Repositories
{
    class SubscriberRepository : ISubscriberRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
        }

        public void Remove(int subscriberId)
        {
            var subscriber = _context
                .Subscribers
                .Single(s => s.Id == subscriberId);

            _context.Subscribers.Remove(subscriber);
        }

        public void Remove(Subscriber subscriber)
        {
            _context.Subscribers.Remove(subscriber);
        }

        public bool Contains(string email)
        {
            return _context.Subscribers.Select(s => s.Email).Contains(email);
        }
    }
}