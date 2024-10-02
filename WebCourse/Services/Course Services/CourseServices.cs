using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;

namespace WebCourse.Services.Course_Services
{
    public class CourseServices : ICourseServices
    {
        private ITI_ProjectContext _context;
        public CourseServices(ITI_ProjectContext context)
        {
            _context = context;
            
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int Id)
        {
            var course = _context.Courses.Find(Id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.Include(c => c.Department).ToList();
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Course? GetCourseById(int Id)
        {
            return _context.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == Id);
        }

        public void UpdateCourse(Course course)
        {
            var currentCourse = _context.Courses.Find(course.Id);

            if (currentCourse != null)
            {
                currentCourse.Name = course.Name;
                currentCourse.Degree = course.Degree;
                currentCourse.Mindegree = course.Mindegree;
                currentCourse.DepartmentId = course.DepartmentId;


                _context.SaveChanges();
            }

        }
    }
}
