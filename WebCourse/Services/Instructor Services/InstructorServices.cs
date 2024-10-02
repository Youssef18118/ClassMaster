using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;

namespace WebCourse.Services.Instructor_Services
{
    public class InstructorServices : I_InstructorServices
    {
        private readonly ITI_ProjectContext _context;
        public InstructorServices(ITI_ProjectContext context)
        {
            _context = context;
        }

        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public void DeleteInstructor(int Id)
        {
            var emp = _context.Instructors.Find(Id);
            _context.Instructors.Remove(emp);
            _context.SaveChanges();
        }

        public List<Course>? GetallCourses()
        {
            return _context.Courses.ToList();
        }
        public List<Department>? GetallDepartments()
        {
            return _context.Departments.ToList();
        }

        public List<Instructor>? GetallInstructors()
        {
            return _context.Instructors.Include(I => I.Course).Include(I => I.Department).ToList();
        }

        public Instructor? GetInstructorById(int id)
        {
            return _context.Instructors.Include(I => I.Course).Include(I => I.Department).FirstOrDefault(I => I.Id == id);
        }

        public void UpdateInstructor(Instructor instructor)
        {
            var existingInstructor = _context.Instructors.Find(instructor.Id);

            if (existingInstructor != null)
            {
                existingInstructor.Name = instructor.Name;
                existingInstructor.Salary = instructor.Salary;
                existingInstructor.Address = instructor.Address;
                existingInstructor.Image = instructor.Image;
                existingInstructor.DepartmentId = instructor.DepartmentId;
                existingInstructor.CourseId = instructor.CourseId;

                _context.SaveChanges();
            }
        }
    }
}
