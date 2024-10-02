using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCourse.Models;

namespace WebCourse.Context
{
    public class ITI_ProjectContext: IdentityDbContext
    {
        public ITI_ProjectContext(DbContextOptions<ITI_ProjectContext> options)
            : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-ENMCV91D\\SQL2022;Initial Catalog=ITI_Project;Integrated Security=True;TrustServerCertificate=True;");
        }
    }
}
