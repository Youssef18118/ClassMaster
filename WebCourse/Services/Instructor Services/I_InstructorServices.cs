using WebCourse.Models;

namespace WebCourse.Services.Instructor_Services
{
    public interface I_InstructorServices
    {
        List<Instructor>? GetallInstructors();
        Instructor? GetInstructorById(int Id);
        List<Department>? GetallDepartments();
        List<Course>? GetallCourses();

        void AddInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void DeleteInstructor(int Id);
    }
}
