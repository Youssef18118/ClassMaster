using WebCourse.Models;

namespace WebCourse.Services.Trainee_Services
{
    public interface ITraineeServices
    {
        List<Trainee>? GetallTrainees();
        Trainee? GetTraineeById(int Id);
        List<Department> GetallDepartments();
        
        void AddTrainee(Trainee trainee);
        void UpdateTrainee(Trainee trainee);
        void DeleteTrainee(Trainee trainee);
    }
}
