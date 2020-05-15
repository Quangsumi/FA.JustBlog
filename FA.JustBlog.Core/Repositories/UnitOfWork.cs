using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using System;

namespace FA.JustBlog.Core.Repositories.Implement
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public JustBlogContext JustBlogContext { get; }

        public IRepository<Category> CategoryRepository { get; }

        public IRepository<Comment> CommentRepository { get; }

        public IRepository<Post> PostRepository { get; }

        public IRepository<Tag> TagRepository { get; }

        public UnitOfWork(JustBlogContext justBlogContext,
            IRepository<Category> categoryRepository,
            IRepository<Comment> commentRepository,
            IRepository<Post> postRepository,
            IRepository<Tag> tagRepository)
        {
            JustBlogContext = justBlogContext;
            CategoryRepository = categoryRepository;
            CommentRepository = commentRepository;
            PostRepository = postRepository;
            TagRepository = tagRepository;

            CategoryRepository.DbContext = JustBlogContext;
            CommentRepository.DbContext = JustBlogContext;
            PostRepository.DbContext = JustBlogContext;
            TagRepository.DbContext = JustBlogContext;
        }

        public int SaveChanges()
        {
            return JustBlogContext.SaveChanges();
        }

        public void Dispose()
        {
            JustBlogContext.Dispose();
        }
    }
}
