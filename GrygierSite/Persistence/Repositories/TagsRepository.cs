using GrygierSite.Core.Models;
using GrygierSite.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GrygierSite.Persistence.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly ApplicationDbContext _context;

        public TagsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Tag GetTag(string tag)
        {
            return _context.Tags.SingleOrDefault(t => t.Name == tag);
        }

        public Tag GetTag(int tagId)
        {
            return _context.Tags.SingleOrDefault(t => t.Id == tagId);
        }

        public IEnumerable<Tag> GetTags()
        {
            return _context.Tags;
        }

        public IEnumerable<Tag> GetTags(int count)
        {
            return _context.Tags.Take(count).ToList();
        }
    }
}