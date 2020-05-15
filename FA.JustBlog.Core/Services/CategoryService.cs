using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FA.JustBlog.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(Category entity)
        {
            Category rs = _unitOfWork.CategoryRepository.Get(c => c.Id == entity.Id);

            if (rs == null)
            {
                _unitOfWork.CategoryRepository.Add(entity);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }

        public int Count()
        {
            return _unitOfWork.CategoryRepository.GetAll().Count();
        }

        public bool Delete(int categoryId)
        {
            Category rs = _unitOfWork.CategoryRepository.GetById(categoryId);

            if (rs == null)
                throw new Exception("Could not find Category Id");

            _unitOfWork.CategoryRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public bool Delete(Category entity)
        {
            Category rs = _unitOfWork.CategoryRepository.GetById(entity.Id);

            if (rs == null)
                throw new Exception("Could not find Category");

            _unitOfWork.CategoryRepository.Delete(rs);

            return _unitOfWork.SaveChanges() > 0;
        }

        public Category Find(int id)
        {
            return _unitOfWork.CategoryRepository.GetById(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }

        public IQueryable<Category> GetMany(Expression<Func<Category, bool>> predicate)
        {
            return _unitOfWork.CategoryRepository.GetMany(predicate);
        }

        public int Update(Category entity)
        {
            Category rs = _unitOfWork.CategoryRepository.GetById(entity.Id);

            if (rs != null)
            {
                rs.Name = entity.Name;
                rs.UrlSlug = entity.UrlSlug;
                rs.Description = entity.Description;

                _unitOfWork.CategoryRepository.Update(rs);
                return _unitOfWork.SaveChanges();
            }

            return 0;
        }
    }
}
