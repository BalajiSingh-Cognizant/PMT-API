using PMTDataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace PMTDataAccess.Validations
{
    public class SkillsValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var project = (ProjectMember)validationContext.ObjectInstance;
            return project.Skills.Count > 3 ? ValidationResult.Success : new ValidationResult("Member should possess atleast 3 skillsets");
        }
    }
}
