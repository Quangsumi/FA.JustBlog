using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using FA.JustBlog.ExternalConfig;
using FA.JustBlog.ViewModels;
using System.Collections.Generic;
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
            return View();
        }

        public ActionResult Details(int year, int month, string urlslug)
        {
            Post post = _postService.GetPostsByYearMonthUrlSlug(year, month, urlslug);

            if(post == null)
                return HttpNotFound();

            PostViewModel postViewModel = new PostViewModel();

            AutoMapperConfiguration.Mapper.Map(post, postViewModel);

            return View(postViewModel);
        }

        [ChildActionOnly]
        public ActionResult MostViewedPosts()
        {
            IEnumerable<Post> posts =_postService.GetMostViewedPost(5);
            ViewBag.Flag = "MostViewedPosts";

            return PartialView("_PartialListPosts", posts);
        }

        [ChildActionOnly]
        public ActionResult LastestPosts()
        {
            IEnumerable<Post> posts = _postService.GetLatestPost(5);
            ViewBag.Flag = "LastestPosts";

            return PartialView("_PartialListPosts", posts);
        }
    }
}