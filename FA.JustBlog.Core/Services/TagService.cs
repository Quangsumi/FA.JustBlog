using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(Tag entity)
        {
            Tag rs = _unitOfWork.TagRepository.Get(t => t.Id == entity.Id);

            if (rs == null)
            {
                _unitOfWork.TagRepository.Add(entity);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }

        public int Count()
        {
            return _unitOfWork.TagRepository.GetAll().Count();
        }

        public bool Delete(int tagId)
        {
            Tag rs = _unitOfWork.TagRepository.GetById(tagId);

            if (rs == null)
                throw new Exception("Could not find Tag Id");

            _unitOfWork.TagRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(Tag entity)
        {
            Tag rs = _unitOfWork.TagRepository.Get(t => t.Id == entity.Id);

            if (rs == null)
                throw new Exception("Could not find Tag");

            _unitOfWork.TagRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public Tag Find(int id)
        {
            return _unitOfWork.TagRepository.GetById(id);
        }

        public IQueryable<Tag> GetAll()
        {
            return _unitOfWork.TagRepository.GetAll();
        }

        public IQueryable<Tag> GetMany(Expression<Func<Tag, bool>> predicate)
        {
            return _unitOfWork.TagRepository.GetMany(predicate);
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            Tag rs = _unitOfWork.TagRepository.Get(t => t.UrlSlug.ToLower() == urlSlug.ToLower());

            if (rs == null)
                throw new Exception("Could not find Url Slug");

            return rs;
        }

        public int Update(Tag entity)
        {
            Tag rs = _unitOfWork.TagRepository.GetById(entity.Id);

            if (rs != null)
            {
                rs.Name = entity.Name;
                rs.UrlSlug = entity.UrlSlug;
                rs.Description = entity.Description;

                _unitOfWork.TagRepository.Update(rs);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }
    }
}
