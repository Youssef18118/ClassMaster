using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Text.RegularExpressions;

namespace WebCourse.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Name should exceed 2 chars")]
        [MaxLength(20,ErrorMessage ="Name shouldn't exceed 20 chars")]
        public string Name { get; set; }
        [MaxLength(30,ErrorMessage ="Address shouldn't exceed 30 chars")]
        public string Address { get; set; }
        [RegularExpression(@"^.*\.(jpg|png)$", ErrorMessage = "Only .jpg and .png image files are allowed.")]
        public string Image { get; set; }
        public double Grade { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
