using FA.JustBlog.ExternalConfig;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Services;
using FA.JustBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.SlugSortParm = sortOrder == "slug" ? "slug_desc" : "slug";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var categories = _categoryService.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                categories = _categoryService.GetMany(c => c.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    categories = categories.OrderByDescending(c => c.Name);
                    break;
                case "slug":
                    categories = categories.OrderBy(c => c.UrlSlug);
                    break;
                case "slug_desc":
                    categories = categories.OrderByDescending(c => c.UrlSlug);
                    break;
                default:
                    categories = categories.OrderBy(c => c.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(categories.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {

            if (ModelState.IsValid)
            {
                Category category = new Category();

                AutoMapperConfiguration.Mapper.Map(categoryViewModel, category);

                _categoryService.Add(category);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            Category category = _categoryService.Find(id);

            CategoryViewModel categoryViewModel = new CategoryViewModel();

            AutoMapperConfiguration.Mapper.Map(category, categoryViewModel);

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category editingCategory = _categoryService.Find(id);
                editingCategory.Name = categoryViewModel.Name;
                editingCategory.UrlSlug = categoryViewModel.UrlSlug;
                editingCategory.Description = categoryViewModel.Description;

                _categoryService.Update(editingCategory);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Category deletingCategory = _categoryService.Find(id);

            if (deletingCategory != null)
            {
                _categoryService.Delete(deletingCategory);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}