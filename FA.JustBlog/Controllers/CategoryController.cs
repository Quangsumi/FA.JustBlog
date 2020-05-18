using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        IPostService _postService;

        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }
     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string urlslug)
        {
            IEnumerable<Post> posts = _postService.GetPostsByCategory(urlslug);
            ViewBag.Category = _categoryService.Find(urlslug);

            return View(posts);
        }

        [ChildActionOnly]
        public ActionResult ListCategories()
        {
            IEnumerable<Category> categories = _categoryService.GetAll();

            return PartialView("_PartialListCategories", categories);
        }
    }
}