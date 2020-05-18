using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        ITagService _tagService;
        IPostService _postService;

        public TagController(ITagService tagService, IPostService postService)
        {
            _tagService = tagService;
            _postService = postService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string urlslug)
        {
            IEnumerable<Post> posts = _postService.GetPostsByUrlSlugTag(urlslug);
            Tag tag = _tagService.GetTagByUrlSlug(urlslug);

            if (tag == null)
                return HttpNotFound();

            ViewBag.Tag = tag;

            return View(posts);
        }

        [ChildActionOnly]
        public ActionResult PopularTags()
        {
            IEnumerable<Tag> tags = _tagService.GetPopularTags(10);

            return PartialView("_PartialPopularTags", tags);
        }
    }
}