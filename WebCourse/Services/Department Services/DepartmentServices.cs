using WebCourse.Context;
using WebCourse.Models;

namespace WebCourse.Services.Department_Services
{
    public class DepartmentServices: IDepartmentServices
    {
        private ITI_ProjectContext _context;
        public DepartmentServices(ITI_ProjectContext context)
        {
            _context = context;
            
        }
        List<Department>? IDepartmentServices.GetAllDepartments() 
        { 
            return _context.Departments.ToList();
        }

        Department? IDepartmentServices.GetDepartmentById(int Id)
        {
            return _context.Departments.FirstOrDefault(c => c.Id == Id);
        }

        void IDepartmentServices.AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        void IDepartmentServices.UpdateDepartment(Department department)
        {
            var currentDepartment = _context.Departments.Find(department.Id);

            if (currentDepartment != null)
            {
                currentDepartment.Name = department.Name;
                currentDepartment.DepartmentManager = department.DepartmentManager;

                _context.SaveChanges();
            }
        }

        void IDepartmentServices.DeleteDepartment(int Id)
        {
            var department = _context.Departments.Find(Id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

    }
}
