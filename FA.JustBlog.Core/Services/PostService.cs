using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(Post entity)
        {
            Post rs = _unitOfWork.PostRepository.Get(p => p.Id == entity.Id);

            if (rs == null)
            {
                _unitOfWork.PostRepository.Add(entity);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }

        public int Count()
        {
            return _unitOfWork.PostRepository.GetAll().Count();
        }

        public int CountPostsForCategory(string category)
        {
            Category rs = _unitOfWork.CategoryRepository.Get(c => c.Name.ToString() == category.ToLower());

            if (rs == null)
                throw new Exception("Could not found Category");

            if (rs.Posts == null)
                throw new Exception("Posts in category are null");

            return rs.Posts.Count;
        }

        public int CountPostsForTag(string tag)
        {
            List<Post> allTagPosts = _unitOfWork.PostRepository.GetAll().ToList();

            List<Post> posts = new List<Post>();

            foreach (Post p in allTagPosts)
            {
                foreach (Tag t in p.Tags)
                {
                    if (t.Name == tag)
                    {
                        posts.Add(p);
                        break;
                    }
                }
            }

            return posts.Count();
        }

        public bool Delete(Post entity)
        {
            Post rs = _unitOfWork.PostRepository.Get(c => c.Id == entity.Id);

            if (rs == null)
                throw new Exception("Could not find Post");

            _unitOfWork.PostRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(int postId)
        {
            Post rs = _unitOfWork.PostRepository.GetById(postId);

            if (rs == null)
                throw new Exception("Could not find Post Id");

            _unitOfWork.PostRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public Post Find(int year, int month, string urlSlug)
        {
            return _unitOfWork.PostRepository.Get(p =>
                    p.UrlSlug.ToLower() == urlSlug.ToLower()
                    && p.PostedOn.Year == year
                    && p.PostedOn.Month == month);
        }

        public Post Find(int id)
        {
            return _unitOfWork.PostRepository.GetById(id);
        }

        public IQueryable<Post> GetAll()
        {
            return _unitOfWork.PostRepository.GetAll();
        }

        public IEnumerable<Post> GetHighestPosts(int size)
        {
            return _unitOfWork.PostRepository.DbSet.OrderByDescending(p => p.Rate).Take(size).ToList();
        }

        public IEnumerable<Post> GetLatestPost(int size)
        {
            return _unitOfWork.PostRepository.DbSet.OrderByDescending(p => p.Published).Take(size).ToList();
        }

        public IQueryable<Post> GetMany(Expression<Func<Post, bool>> predicate)
        {
            return _unitOfWork.PostRepository.GetMany(predicate);
        }

        public IEnumerable<Post> GetMostViewedPost(int size)
        {
            return _unitOfWork.PostRepository.DbSet.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }

        public IEnumerable<Post> GetPostsByCategory(string category)
        {
            Category rs = _unitOfWork.CategoryRepository.Get(c => c.Name.ToLower() == category.ToLower());

            if (rs == null)
                throw new Exception("Could not find Category Id");

            return _unitOfWork.PostRepository.DbSet.Where(p => p.CategoryId == rs.Id).ToList();
        }

        public IEnumerable<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _unitOfWork.PostRepository.GetMany(p => p.PostedOn.Month == monthYear.Month).ToList();
        }

        public IEnumerable<Post> GetPostsByTag(string tag)
        {
            List<Post> allTagPosts = _unitOfWork.PostRepository.GetAll().ToList();

            List<Post> posts = new List<Post>();

            foreach (Post p in allTagPosts)
            {
                foreach (Tag t in p.Tags)
                {
                    if (t.Name == tag)
                    {
                        posts.Add(p);
                        break;
                    }
                }
            }

            return posts;
        }

        public IEnumerable<Post> GetPublisedPosts()
        {
            return _unitOfWork.PostRepository.GetMany(p => p.Published == true).ToList();
        }

        public IEnumerable<Post> GetUnpublisedPosts()
        {
            return _unitOfWork.PostRepository.GetMany(p => p.Published == false).ToList();
        }

        public int Update(Post entity)
        {
            Post rs = _unitOfWork.PostRepository.GetById(entity.Id);

            if (rs != null)
            {
                rs.Title = entity.Title;
                rs.ShortDescription = entity.ShortDescription;
                rs.Meta = entity.Meta;
                rs.UrlSlug = entity.UrlSlug;
                rs.Published = entity.Published;
                rs.Modified = DateTime.Now;
                rs.CategoryId = entity.CategoryId;
                rs.PostContent = entity.PostContent;
                rs.Tags = entity.Tags;

                _unitOfWork.PostRepository.Update(rs);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }
    }
}
