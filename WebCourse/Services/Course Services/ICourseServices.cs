using WebCourse.Models;

namespace WebCourse.Services.Course_Services
{
    public interface ICourseServices
    {
        List<Course> GetAllCourses();
        Course? GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
        List<Department> GetAllDepartments();
    }
}
