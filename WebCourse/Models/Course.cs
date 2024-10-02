using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCourse.Validators;

namespace WebCourse.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [MinLength (3, ErrorMessage ="Min Length is 3"),]
        [MaxLength (100, ErrorMessage = "Max Length is 100")]
        [UniqueValidator(true)]
        public string Name { get; set; }
        public string Degree { get; set; }
        public string? Mindegree { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}
