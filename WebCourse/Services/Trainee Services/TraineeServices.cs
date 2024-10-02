using Microsoft.EntityFrameworkCore;
using WebCourse.Context;
using WebCourse.Models;

namespace WebCourse.Services.Trainee_Services
{
    public class TraineeServices: ITraineeServices
    {
        private readonly ITI_ProjectContext _context;
        public TraineeServices(ITI_ProjectContext context)
        {
            _context = context;
        }

        public void AddTrainee(Trainee trainee)
        {
            _context.Trainees.Add(trainee);
            _context.SaveChanges();
        }

        public void DeleteTrainee(Trainee trainee)
        {
            _context.Trainees.Remove(trainee);
            _context.SaveChanges();
        }

        public List<Department> GetallDepartments()
        {
            return _context.Departments.ToList();
        }

        public List<Trainee>? GetallTrainees()
        {
            return _context.Trainees.Include(t => t.Department).ToList(); 
        }

        public Trainee? GetTraineeById(int Id)
        {
            return _context.Trainees.Include(t => t.Department).FirstOrDefault(t => t.Id == Id);
        }

        public void UpdateTrainee(Trainee trainee)
        {
            var currentTrainee = _context.Trainees.Find(trainee.Id);

            if (currentTrainee != null)
            {
                currentTrainee.Name = trainee.Name;
                currentTrainee.Address = trainee.Address;
                currentTrainee.Image = trainee.Image;
                currentTrainee.Grade = trainee.Grade;
                currentTrainee.DepartmentId = trainee.DepartmentId;

                _context.SaveChanges();
            }
        }
    }
}
