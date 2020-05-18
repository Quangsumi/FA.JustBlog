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
    public class HomeController : Controller
    {
        IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public ActionResult Index()
        {
            List<Post> posts = _postService.GetLatestPost(10).ToList();
            List<PostViewModel> postViewModels = new List<PostViewModel>();

            AutoMapperConfiguration.Mapper.Map(posts, postViewModels);

            return View(postViewModels);
        }

        [ChildActionOnly]
        public ActionResult AboutCard()
        {
            return PartialView("_PartialAboutCard");
        }
    }
}