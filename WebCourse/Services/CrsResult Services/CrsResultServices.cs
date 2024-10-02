using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;
using WebCourse.ViewModels;

namespace WebCourse.Services.CrsResult_Services
{
    public class CrsResultServices : ICrsResultServices
    {
        private readonly ITI_ProjectContext _context;
        public CrsResultServices(ITI_ProjectContext context)
        {
            _context = context;
        }

        List<CrsResult>? ICrsResultServices.GetCrsResultsById(int Id)
        {
            return _context.CrsResults
                .Include(crs => crs.Trainee)
                .ThenInclude(t => t.Department)
                .Include(crs => crs.Course)
                .Where(crs => crs.TraineeId == Id)
                .ToList();
        }

        public List<crsResultIndexVM>? GetTrainees()
        {
            return _context.Trainees
                .Include(t => t.Department)
                .Where(t => _context.CrsResults.Any(crs => crs.TraineeId == t.Id)) // Include only trainees with course results
                .Select(t => new crsResultIndexVM
                {
                    Id = t.Id,
                    Name = t.Name,
                    DepartmentName = t.Department.Name
                })
                .ToList();
        }

        public CrsResultDetailsVM? AssignCrsResDetails(List<CrsResult> result)
        {
            CrsResultDetailsVM datavm = new CrsResultDetailsVM();

            datavm.TraineeName = result.FirstOrDefault().Trainee?.Name;
            datavm.TraineeId = result.FirstOrDefault().Trainee?.Id;
            datavm.DeptName = result.FirstOrDefault().Trainee?.Department?.Name;
            datavm.Courses = result.Select(crs => crs.Course?.Name).ToList();
            datavm.Grades = result.Select(crs => crs.Degree).ToList();
            datavm.CourseIds = result.Select(crs => crs.CourseId).ToList();

            List<string> colors = new List<string>();
            int i = 0;

            foreach(string e in datavm.Grades)
            {
                if(e == "Pass")
                {
                    colors.Add( "green");
                }
                else
                {
                    colors.Add("red");
                }
                i++;
            }

            datavm.Colors = colors;
            return datavm;
        }

        public List<Trainee>? GetallTrainees()
        {
            return _context.Trainees.ToList();
        }

        public List<Course>? GetallCourses()
        {
            return _context.Courses.ToList();   
        }

        public void AddCrsResult(CrsResult result)
        {
            _context.CrsResults.Add(result);
            _context.SaveChanges();
        }

        public void DeleteCrsResult(int Id)
        {
            var results = _context.CrsResults.Where(c => c.TraineeId == Id);
            foreach (CrsResult result in results)
            {
                _context.CrsResults.Remove(result);

            }
            _context.SaveChanges();
        }

        public CrsResult? GetCrsResultswithIds(int traineeId, int courseId)
        {
            return _context.CrsResults.FirstOrDefault(c => c.TraineeId == traineeId && c.CourseId == courseId);
        }

        public void DeleteCrsResult(CrsResult crsResult)
        {
            _context.CrsResults.Remove(crsResult);
            _context.SaveChanges();
        }

        public bool GetRemainingCourses(int traineeId)
        {
            return _context.CrsResults.Any(c => c.TraineeId == traineeId);
        }
    }
}
