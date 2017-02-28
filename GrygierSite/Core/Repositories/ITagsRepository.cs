using System.Collections.Generic;
using GrygierSite.Core.Models;

namespace GrygierSite.Core.Repositories
{
    public interface ITagsRepository
    {
        Tag GetTag(string tag);
        IEnumerable<Tag> GetTags();
        IEnumerable<Tag> GetTags(int count);
    }
}