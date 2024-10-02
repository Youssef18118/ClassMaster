using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCourse.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Name must exceed 3 Chars")]
        [MaxLength(20, ErrorMessage ="Name must not exceed 20 Chars")]
        public string Name { get; set; }
        [Range(2000, 15000,ErrorMessage ="Salary should be in range (2000,15000)")]
        public double Salary { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        public Course? Course { get; set; }


    }
}
