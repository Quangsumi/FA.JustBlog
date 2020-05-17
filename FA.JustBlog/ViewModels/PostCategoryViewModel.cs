using FA.JustBlog.Core.Models;
using System.Collections.Generic;

namespace FA.JustBlog.ViewModels
{
    public class PostCategoryViewModel
    {
        public Post Post { get; set; }

        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }
    }
}