using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;
using WebCourse.Services.Course_Services;

namespace WebCourse.Controllers
{
    public class CourseController : Controller
    {
        private ICourseServices _services;
        public CourseController(ICourseServices services)
        {
            _services = services;
        }


        [Route("/getallcs")]
        public IActionResult Index()
        {
            //get all
            var Courses = _services.GetAllCourses();
            return View(Courses);
        }

        [Route("/csdetail/{Id}")]
        public IActionResult Details(int Id)
        {
            //get Details
            var Course = _services.GetCourseById(Id);
            return View(Course);
        }

        [Authorize(Roles = "Admin")]
        [Route("/addcs")]
        public IActionResult Add()
        {
            ViewBag.Departments = _services.GetAllDepartments();
            return View();

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveAdd(Course course) 
        {
            if (ModelState.IsValid)
            {
                _services.AddCourse(course);
                return RedirectToAction("Index");

            }
            ViewBag.Departments = _services.GetAllDepartments();
            return View("Add", course);
        }

        [Authorize(Roles = "Admin")]
        [Route("/editcs/{id}")]
        public IActionResult Edit(int Id)
        {
            Course? course = _services.GetCourseById(Id);    
            ViewBag.Departments = _services.GetAllDepartments(); 

            if (course != null)
            {
                return View(course);

            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveEdit(Course course)
        {
            if (ModelState.IsValid)
            {
                _services.UpdateCourse(course);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _services.GetAllDepartments();
            return View("Edit", course);
        }

        [Authorize(Roles = "Admin")]
        [Route("/deltecs/{Id}")]
        public IActionResult delete(int Id)
        {
            _services.DeleteCourse(Id);
            return RedirectToAction("Index");
        }
    }
}
