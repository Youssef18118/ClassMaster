using WebCourse.Models;

namespace WebCourse.Services.Department_Services
{
    public interface IDepartmentServices
    {
        List<Department>? GetAllDepartments();
        Department? GetDepartmentById(int Id);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int Id);




    }
}
