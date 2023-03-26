using BigScholl_2011143452_LeMinhSang.Models;
using BigScholl_2011143452_LeMinhSang.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigScholl_2011143452_LeMinhSang.Controllers
{
    
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public CoursesController()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            _dbcontext = applicationDbContext;
        }

        // GET: Courses
        public ActionResult Create()
        {
            var viewModel = new CourseViewModelcs
            {
                Categories = _dbcontext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModelcs viewModelcs)
        {
            if (!ModelState.IsValid)
            {
                viewModelcs.Categories = _dbcontext.Categories.ToList();
                return View("Create", viewModelcs);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = viewModelcs.GetDateTime(),
                CategoryId = viewModelcs.Category,
                Place = viewModelcs.Place,
            };
            _dbcontext.Courses.Add(course);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}