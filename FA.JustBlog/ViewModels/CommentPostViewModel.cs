using FA.JustBlog.Core.Models;
using System.Collections.Generic;

namespace FA.JustBlog.ViewModels
{
    public class CommentPostViewModel
    {
        public Comment Comment { get; set; }

        public int PostId { get; set; }

        public List<Post> Posts { get; set; }
    }
}