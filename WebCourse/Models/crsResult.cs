using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCourse.Models
{
    public class CrsResult
    {
        [Key]
        public int Id { get; set; }
        public string Degree { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("Trainee")]
        public int? TraineeId { get; set; }
        public Trainee? Trainee { get; set; }
    }
}
