using System.ComponentModel.DataAnnotations;
using WebCourse.Validators;

namespace WebCourse.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [UniqueValidator(false)]
        [MinLength(3, ErrorMessage ="Min length is 3")]
        [MaxLength(25, ErrorMessage = "Max length is 25")]
        public string Name { get; set; }
        [Required]
        public string DepartmentManager { get; set; }
    }
}
