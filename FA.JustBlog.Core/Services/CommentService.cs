using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            Comment comment = new Comment()
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody
            };

            _unitOfWork.CommentRepository.Add(comment);

            return _unitOfWork.SaveChanges();
        }

        public int Add(Comment entity)
        {
            Comment rs = _unitOfWork.CommentRepository.Get(c => c.Id == entity.Id);

            if (rs == null)
            {
                _unitOfWork.CommentRepository.Add(entity);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }

        public int Count()
        {
            return _unitOfWork.CommentRepository.GetAll().Count();
        }

        public bool Delete(int commentId)
        {
            Comment rs = _unitOfWork.CommentRepository.GetById(commentId);

            if (rs == null)
                throw new Exception("Could not found Comment Id");

            _unitOfWork.CommentRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(Comment entity)
        {
            Comment rs = _unitOfWork.CommentRepository.GetById(entity.Id);

            if (rs == null)
                throw new Exception("Could not find Comment");

            _unitOfWork.CommentRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public Comment Find(int id)
        {
            return _unitOfWork.CommentRepository.GetById(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return _unitOfWork.CommentRepository.GetAll();
        }

        public IEnumerable<Comment> GetCommentsForPost(int postId)
        {
            Post rs = _unitOfWork.PostRepository.GetById(postId);

            if (rs == null)
                throw new Exception("Could not found Post Id");

            return _unitOfWork.CommentRepository.DbSet.Where(c => c.PostId == postId).ToList();
        }

        public IEnumerable<Comment> GetCommentsForPost(Post post)
        {
            Post rs = _unitOfWork.PostRepository.GetById(post.Id);

            if (rs == null)
                throw new Exception("Could not found Post");

            return _unitOfWork.CommentRepository.DbSet.Where(c => c.PostId == post.Id).ToList();
        }

        public IQueryable<Comment> GetMany(Expression<Func<Comment, bool>> predicate)
        {
            return _unitOfWork.CommentRepository.GetMany(predicate);
        }

        public int Update(Comment entity)
        {
            Comment rs = _unitOfWork.CommentRepository.GetById(entity.Id);

            if (rs != null)
            {
                rs.Name = entity.Name;
                rs.Email = entity.Email;
                rs.PostId = entity.PostId;
                rs.CommentHeader = entity.CommentHeader;
                rs.CommentText = entity.CommentText;
                rs.CommentTime = DateTime.Now;

                _unitOfWork.CommentRepository.Update(rs);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }
    }
}
