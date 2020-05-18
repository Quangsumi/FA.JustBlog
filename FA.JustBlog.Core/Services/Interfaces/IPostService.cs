using System;
using System.Collections.Generic;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Services
{
    public interface IPostService : IService<Post>
    {
        int CountPostsForCategory(string category);
        int CountPostsForTag(string tag);
        bool Delete(int postId);
        Post Find(int year, int month, string urlSlug);
        IEnumerable<Post> GetHighestPosts(int size);
        IEnumerable<Post> GetLatestPost(int size);
        IEnumerable<Post> GetMostViewedPost(int size);
        IEnumerable<Post> GetPostsByCategory(string urlSlug);
        IEnumerable<Post> GetPostsByCategoryId(int id);
        IEnumerable<Post> GetPostsByMonth(DateTime monthYear);
        Post GetPostsByYearMonthUrlSlug(int year, int month, string urlslug);
        IEnumerable<Post> GetPostsByUrlSlugTag(string urlSlug);
        IEnumerable<Post> GetPostsByTagById(int id);
        IEnumerable<Post> GetPublisedPosts();
        IEnumerable<Post> GetUnpublisedPosts();
    }
}