using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using FA.JustBlog.ExternalConfig;
using FA.JustBlog.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        IPostService _postService;

        public CommentController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParm = sortOrder == "email" ? "email_desc" : "email";
            ViewBag.PostTitleSortParm = sortOrder == "postTitle" ? "postTitle_desc" : "postTitle";
            ViewBag.TimeSortParm = sortOrder == "time" ? "time_desc" : "time";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var comments = _commentService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                comments = _commentService.GetMany(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    comments = comments.OrderByDescending(c => c.Name);
                    break;
                case "email":
                    comments = comments.OrderBy(c => c.Email);
                    break;
                case "email_desc":
                    comments = comments.OrderByDescending(c => c.Email);
                    break;
                case "postTitle":
                    comments = comments.OrderBy(c => c.Post.Title);
                    break;
                case "postTitle_desc":
                    comments = comments.OrderByDescending(c => c.Post.Title);
                    break;
                case "time":
                    comments = comments.OrderBy(c => c.CommentTime);
                    break;
                case "time_desc":
                    comments = comments.OrderByDescending(c => c.CommentTime);
                    break;
                default:
                    comments = comments.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(comments.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            CommentPostViewModel commentPostViewModel = new CommentPostViewModel();
            commentPostViewModel.Posts = _postService.GetAll().ToList();

            return View(commentPostViewModel);
        }

        [HttpPost]
        public ActionResult Create(CommentPostViewModel commentPostView)
        {
            if (ModelState.IsValid)
            {
                commentPostView.Comment.CommentTime = DateTime.Now;
                commentPostView.Comment.PostId = commentPostView.PostId;

                _commentService.Add(commentPostView.Comment);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Comment comment = _commentService.Find(id);

            CommentPostViewModel commentPostViewModel = new CommentPostViewModel();
            commentPostViewModel.Posts = _postService.GetAll().ToList();
            commentPostViewModel.Comment = comment;

            return View(commentPostViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CommentPostViewModel commentPostViewModel)
        {
            if (ModelState.IsValid)
            {
                Comment editingComment = _commentService.Find(id);
                editingComment.Name = commentPostViewModel.Comment.Name;
                editingComment.Email = commentPostViewModel.Comment.Email;
                editingComment.PostId = commentPostViewModel.PostId;
                editingComment.CommentHeader = commentPostViewModel.Comment.CommentHeader;
                editingComment.CommentText = commentPostViewModel.Comment.CommentText;

                _commentService.Update(editingComment);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Comment deletingComment = _commentService.Find(id);

            if (deletingComment != null)
            {
                _commentService.Delete(deletingComment);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}