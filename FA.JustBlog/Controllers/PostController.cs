using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using FA.JustBlog.ExternalConfig;
using FA.JustBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class PostController : Controller
    {
        IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult Index()
        {
            List<Post> posts = _postService.GetAll().ToList();
            List<PostViewModel> postViewModels = new List<PostViewModel>();

            AutoMapperConfiguration.Mapper.Map(posts, postViewModels);

            return View(postViewModels);
        }

        public ActionResult Details(int id)
        {
            Post post = _postService.Find(id);
            PostViewModel postViewModel = new PostViewModel();

            AutoMapperConfiguration.Mapper.Map(post, postViewModel);

            return View(postViewModel);
        }
    }
}