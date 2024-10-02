using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;
using WebCourse.Services.Instructor_Services;

namespace WebCourse.Controllers
{
    public class InstructorController : Controller
    {
        private readonly I_InstructorServices _services;
        public InstructorController(I_InstructorServices services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var Instructors = _services.GetallInstructors();
            return View(Instructors);
        }

        [Route("/getall/{id}")]
        public IActionResult detail(int id)
        {
            var Instructor = _services.GetInstructorById(id);
            
            if (Instructor == null)
            {
                return NotFound();
            }
            return View(Instructor);
        }

        [Authorize(Roles = "Admin")]
        [Route("/add")]
        public IActionResult Add()
        {
            ViewBag.Departments = _services.GetallDepartments();
            ViewBag.Courses = _services.GetallCourses();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveAdd(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _services.AddInstructor(instructor);
                return RedirectToAction("Index");

            }
            ViewBag.Departments = _services.GetallDepartments();
            ViewBag.Courses = _services.GetallCourses();
            return View("Add", instructor);
        }

        [Authorize(Roles = "Admin")]
        [Route("/modify/{Id}")]
        public IActionResult Edit(int Id)
        {
            Instructor? instructor =_services.GetInstructorById(Id);


            ViewBag.Departments = _services.GetallDepartments();
            ViewBag.Courses = _services.GetallCourses();

            if (instructor != null)
            {
                return View(instructor);

            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveEdit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _services.UpdateInstructor(instructor);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _services.GetallDepartments();
            ViewBag.Courses = _services.GetallCourses();
            return View("Edit", instructor);
        }

        [Authorize(Roles = "Admin")]
        [Route("del/{Id}")]
        public IActionResult delete(int Id)
        {
            _services.DeleteInstructor(Id);
            return RedirectToAction("Index");
        }

    }
}
