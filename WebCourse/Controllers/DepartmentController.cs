using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;
using WebCourse.Services.Department_Services;

namespace WebCourse.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _services;
        public DepartmentController(IDepartmentServices services)
        {
            _services = services;
        }

        [Route("/getalldep")]
        public IActionResult Index()
        {
            //get all
            var Departments = _services.GetAllDepartments();
            return View(Departments);
        }

        [Route("/getalldep/{Id}")]
        public IActionResult Details(int Id)
        {
            //get Details
            var department = _services.GetDepartmentById(Id);
            return View(department);
        }

        [Authorize(Roles = "Admin")]
        [Route("/adddep")]
        public IActionResult Add()
        {
            return View();

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveAdd(Department department)
        {
            if (ModelState.IsValid)
            {
                _services.AddDepartment(department);
                return RedirectToAction("Index");

            }
            return View("Add", department);
        }

        [Authorize(Roles = "Admin")]
        [Route("/editdep/{Id}")]
        public IActionResult Edit(int Id)
        {
            Department? department = _services.GetDepartmentById(Id);

            if (department != null)
            {
                return View(department);

            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveEdit(Department department)
        {
            if (ModelState.IsValid)
            {
                _services.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            return View("Edit", department);
        }

        [Authorize(Roles = "Admin")]
        [Route("/deldep/{Id}")]
        public IActionResult delete(int Id)
        {

            _services.DeleteDepartment(Id);
            return RedirectToAction("Index");
        }
    }
}
