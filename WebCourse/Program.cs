using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCourse.Context;
using WebCourse.Services.Course_Services;
using WebCourse.Services.CrsResult_Services;
using WebCourse.Services.Department_Services;
using WebCourse.Services.Instructor_Services;
using WebCourse.Services.Trainee_Services;
using Microsoft.EntityFrameworkCore;

namespace WebCourse
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ICourseServices, CourseServices>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<I_InstructorServices, InstructorServices>();
            builder.Services.AddScoped<ITraineeServices, TraineeServices>();
            builder.Services.AddScoped<ICrsResultServices, CrsResultServices>();

            // Register the DbContext with AddDbContext
            builder.Services.AddDbContext<ITI_ProjectContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add Identity services
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ITI_ProjectContext>();

            var app = builder.Build();

            // Seed roles and admin user during application startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await RoleSeeder.SeedRolesAndAdminUser(services);
            }

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // Add this line to handle authentication
            app.UseAuthorization();  // Add this line to handle authorization

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Instructor}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "crsResult",
                pattern: "{controller=CrsResult}/{action=Index}/{id?}/{id2?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}
