using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebCourse.Context;
using WebCourse.Models;
using WebCourse.Services.CrsResult_Services;
using WebCourse.ViewModels;

namespace WebCourse.Controllers
{
    public class CrsResultController : Controller
    {
        private readonly ICrsResultServices _services;
        public CrsResultController(ICrsResultServices services)
        {
            _services = services;
        }

        [Route("/getallres")]
        public IActionResult Index()
        {
            var trainees = _services.GetTrainees();
            return View(trainees);
        }

        [Route("/getallres/{Id}")]
        public IActionResult Details(int Id)
        {
            var result = _services.GetCrsResultsById(Id);

            if (result == null || result.Count == 0)
            {
                return Content("This Trainee didn't enroll in courses yet");
            }


            var datavm = _services.AssignCrsResDetails(result);
            return View(datavm);
        }

        [Authorize(Roles = "Admin")]
        [Route("/addres")]
        public IActionResult Add()
        {
            ViewBag.Trainees = _services.GetallTrainees();
            ViewBag.Courses = _services.GetallCourses();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveAdd(CrsResult crsResult)
        {
            if (ModelState.IsValid)
            {
                _services.AddCrsResult(crsResult);
                return RedirectToAction("Index");
            }
            ViewBag.Trainees = _services.GetallTrainees();
            ViewBag.Courses = _services.GetallCourses();
            return View("Add", crsResult);
        }

        [Authorize(Roles = "Admin")]
        [Route("/deleteres/{Id}")]
        public IActionResult delete(int Id)
        {
            _services.DeleteCrsResult(Id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [Route("/deletecrsres")]
        public IActionResult deleteCourse(int traineeId, int courseId)
        {
            var result = _services.GetCrsResultswithIds(traineeId, courseId);
            if (result == null)
            {
                return Content("This trainee hasn't enrolled in this course yet");
            }

            _services.DeleteCrsResult(result);

            var remainingCourses = _services.GetRemainingCourses(traineeId);
            if (!remainingCourses)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", new { Id = traineeId });
        }

    }
}
