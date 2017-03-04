using System.Collections.Generic;
using GrygierSite.Core.Models;

namespace GrygierSite.Core.Repositories
{
    public interface ITagsRepository
    {
        Tag GetTag(string tag);
        Tag GetTag(int tagId);
        IEnumerable<Tag> GetTags();
        IEnumerable<Tag> GetTags(int count);
    }
}