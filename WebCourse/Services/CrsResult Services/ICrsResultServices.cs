using WebCourse.Models;
using WebCourse.ViewModels;

namespace WebCourse.Services.CrsResult_Services
{
    public interface ICrsResultServices
    {
        List<crsResultIndexVM>? GetTrainees();
        List<CrsResult>? GetCrsResultsById(int Id);
        List<Trainee>? GetallTrainees();
        List<Course>? GetallCourses();
        CrsResult? GetCrsResultswithIds(int traineeId, int courseId);
        CrsResultDetailsVM? AssignCrsResDetails(List<CrsResult> result);
        bool GetRemainingCourses(int trianeeId);

        void AddCrsResult(CrsResult result);
        void DeleteCrsResult(int Id);
        void DeleteCrsResult(CrsResult crsResult);


    }
}
