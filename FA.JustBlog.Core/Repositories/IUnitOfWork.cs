using System.Threading.Tasks;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repositories.Implement
{
    public interface IUnitOfWork
    {
        IRepository<Category> CategoryRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        JustBlogContext JustBlogContext { get; }
        IRepository<Post> PostRepository { get; }
        IRepository<Tag> TagRepository { get; }
        void Dispose();
        int SaveChanges();
    }
}