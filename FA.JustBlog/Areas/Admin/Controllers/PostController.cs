using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using FA.JustBlog.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        IPostService _postService;
        ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.PublishedSortParm = sortOrder == "published" ? "published_desc" : "published";
            ViewBag.PostedOnSortParm = sortOrder == "postedOn" ? "postedOn_desc" : "postedOn";
            ViewBag.ModifiedSortParm = sortOrder == "modified" ? "modified_desc" : "modified";
            ViewBag.CategorySortParm = sortOrder == "category" ? "category_desc" : "category";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var posts = _postService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                posts = _postService.GetMany(c => c.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    posts = posts.OrderByDescending(c => c.Title);
                    break;
                case "published":
                    posts = posts.OrderBy(c => c.Published);
                    break;
                case "published_desc":
                    posts = posts.OrderByDescending(c => c.Published);
                    break;
                case "postedOn":
                    posts = posts.OrderBy(c => c.PostedOn);
                    break;
                case "postedOn_desc":
                    posts = posts.OrderByDescending(c => c.PostedOn);
                    break;
                case "modified":
                    posts = posts.OrderBy(c => c.Modified);
                    break;
                case "modified_desc":
                    posts = posts.OrderByDescending(c => c.Modified);
                    break;
                case "category":
                    posts = posts.OrderBy(c => c.Category.Name);
                    break;
                case "category_desc":
                    posts = posts.OrderByDescending(c => c.Category.Name);
                    break;
                default:
                    posts = posts.OrderBy(c => c.Title);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            PostCategoryViewModel postCategoryViewModel = new PostCategoryViewModel();
            postCategoryViewModel.Categories = _categoryService.GetAll().ToList();

            return View(postCategoryViewModel);
        }

        [HttpPost]
        public ActionResult Create(PostCategoryViewModel postCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                postCategoryViewModel.Post.PostedOn= DateTime.Now;
                postCategoryViewModel.Post.Modified = DateTime.Now;
                postCategoryViewModel.Post.CategoryId = postCategoryViewModel.CategoryId;

                _postService.Add(postCategoryViewModel.Post);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Post post = _postService.Find(id);

            PostCategoryViewModel postCategoryViewModel = new PostCategoryViewModel();
            postCategoryViewModel.Categories = _categoryService.GetAll().ToList();
            postCategoryViewModel.Post = post;

            return View(postCategoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, PostCategoryViewModel postCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Post editingPost = _postService.Find(id);
                editingPost.Title = postCategoryViewModel.Post.Title;
                editingPost.ShortDescription = postCategoryViewModel.Post.ShortDescription;
                editingPost.Meta = postCategoryViewModel.Post.Meta;
                editingPost.UrlSlug = postCategoryViewModel.Post.UrlSlug;
                editingPost.Published = postCategoryViewModel.Post.Published;
                editingPost.Modified = DateTime.Now;
                editingPost.CategoryId = postCategoryViewModel.CategoryId;
                editingPost.PostContent = postCategoryViewModel.Post.PostContent;

                _postService.Update(editingPost);

                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Delete(int id)
        {
            Post deletingPost = _postService.Find(id);

            if (deletingPost != null)
            {
                _postService.Delete(deletingPost);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}