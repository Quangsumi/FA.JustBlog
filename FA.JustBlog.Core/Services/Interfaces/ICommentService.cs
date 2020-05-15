using System.Collections.Generic;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Services
{
    public interface ICommentService : IService<Comment>
    {
        int Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
        bool Delete(int commentId);
        IEnumerable<Comment> GetCommentsForPost(int postId);
        IEnumerable<Comment> GetCommentsForPost(Post post);
    }
}