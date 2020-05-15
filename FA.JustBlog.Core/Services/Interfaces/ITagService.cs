using System.Collections.Generic;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Services
{
    public interface ITagService : IService<Tag>
    {
        bool Delete(int tagId);
        Tag GetTagByUrlSlug(string urlSlug);
    }
}