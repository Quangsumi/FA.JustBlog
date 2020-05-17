using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using FA.JustBlog.ExternalConfig;
using FA.JustBlog.ViewModels;
using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SlugSortParm = sortOrder == "slug" ? "slug_desc" : "slug";
            ViewBag.CountSortParm = sortOrder == "count" ? "count_desc" : "count";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tags = _tagService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                tags = _tagService.GetMany(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    tags = tags.OrderByDescending(c => c.Name);
                    break;
                case "slug":
                    tags = tags.OrderBy(c => c.UrlSlug);
                    break;
                case "slug_desc":
                    tags = tags.OrderByDescending(c => c.UrlSlug);
                    break;
                case "count":
                    tags = tags.OrderBy(c => c.Count);
                    break;
                case "count_desc":
                    tags = tags.OrderByDescending(c => c.Count);
                    break;
                default:
                    tags = tags.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(tags.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                Tag tag = new Tag();

                AutoMapperConfiguration.Mapper.Map(tagViewModel, tag);

                _tagService.Add(tag);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Tag tag = _tagService.Find(id);

            TagViewModel tagViewModel = new TagViewModel();

            AutoMapperConfiguration.Mapper.Map(tag, tagViewModel);

            return View(tagViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, TagViewModel tagViewModel)
        {
            if (ModelState.IsValid)
            {
                Tag editingTag = _tagService.Find(id);
                editingTag.Name = tagViewModel.Name;
                editingTag.UrlSlug = tagViewModel.UrlSlug;
                editingTag.Description = tagViewModel.Description;

                _tagService.Update(editingTag);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Tag deletingTag = _tagService.Find(id);

            if (deletingTag != null)
            {
                _tagService.Delete(deletingTag);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
