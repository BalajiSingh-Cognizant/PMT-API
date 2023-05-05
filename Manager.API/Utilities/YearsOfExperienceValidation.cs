using Manager.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Manager.API.Utilities
{
    public class YearsOfExperienceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var project = (ProjectMember)validationContext.ObjectInstance;
            return project.Experience > 4 ? ValidationResult.Success : new ValidationResult("Experience should be greater than 4 years");
        }
    }
}
