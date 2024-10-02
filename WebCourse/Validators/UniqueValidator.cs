using System.ComponentModel.DataAnnotations;
using WebCourse.Context;

namespace WebCourse.Validators
{
    public class UniqueValidator : ValidationAttribute
    {
        private readonly bool _isCourse;

        public UniqueValidator(bool isCourse)
        {
            _isCourse = isCourse;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Retrieve the DbContext from the service provider
            var db = (ITI_ProjectContext)validationContext.GetService(typeof(ITI_ProjectContext));

            if (db == null)
            {
                throw new InvalidOperationException("DbContext is not available.");
            }

            var name = value as string;
            object? emp;

            if (_isCourse)
            {
                emp = db.Courses.FirstOrDefault(e => e.Name == name);
            }
            else
            {
                emp = db.Departments.FirstOrDefault(e => e.Name == name);
            }

            if (emp == null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Name already exists!");
        }

    }

}
