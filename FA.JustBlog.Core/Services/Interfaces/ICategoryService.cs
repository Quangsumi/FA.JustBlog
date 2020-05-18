using FA.JustBlog.Core.Models;
using System.Collections.Generic;

namespace FA.JustBlog.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        bool Delete(int categoryId);
        Category Find(string urlslug);
    }
}