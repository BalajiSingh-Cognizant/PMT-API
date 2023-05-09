using PMTDataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace PMTDataAccess.Validations
{
    public class TaskDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var project = (TaskMember)validationContext.ObjectInstance;
            return project.StartDate < project.EndDate ? ValidationResult.Success : new ValidationResult("Project End date should be greater than project start date");
        }
    }
}
