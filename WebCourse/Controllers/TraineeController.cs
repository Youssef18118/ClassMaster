using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;
using WebCourse.Services.Trainee_Services;

namespace WebCourse.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeServices _services;
        public TraineeController(ITraineeServices services)
        {
            _services = services;

        }


        [Route("/getalltrainee")]
        public IActionResult Index()
        {
            // get all Trainees
            var students = _services.GetallTrainees();
            return View(students);
        }

        [Route("/getalltrainee/{Id}")]
        public IActionResult Details(int Id)
        {
            // get details
            var student = _services.GetTraineeById(Id);
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [Route("/addtrainee")]
        public IActionResult Add()
        {   
            ViewBag.Departments = _services.GetallDepartments();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveAdd(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _services.AddTrainee(trainee);
                return RedirectToAction("Index");

            }
            ViewBag.Departments = _services.GetallDepartments();
            return View("Add", trainee);
        }

        [Authorize(Roles = "Admin")]
        [Route("/edittrainee/{Id}")]
        public IActionResult Edit(int Id)
        {
            Trainee? trainee = _services.GetTraineeById(Id);
            ViewBag.Departments = _services.GetallDepartments();

            if (trainee != null)
            {
                return View(trainee);

            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveEdit(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _services.UpdateTrainee(trainee);
                return RedirectToAction("Index");
            }

            ViewBag.Departments = _services.GetallDepartments();
            return View("Edit", trainee);
        }

        [Authorize(Roles = "Admin")]
        [Route("/deltrainee/{Id}")]
        public IActionResult delete(int Id)
        {
            var trainee = _services.GetTraineeById(Id);
            if (trainee != null)
            {
                _services.DeleteTrainee(trainee);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
