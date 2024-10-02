namespace WebCourse.ViewModels
{
    public class CrsResultDetailsVM
    {
        public string? TraineeName { get; set; }
        public string? DeptName { get; set; }
        public int? TraineeId { get; set; }

        public List<string>? Colors { get; set; }
        public List<string?> Courses { get; set; }
        public List<string?> Grades { get; set; }
        public List<int?> CourseIds { get; set; }


    }
}
