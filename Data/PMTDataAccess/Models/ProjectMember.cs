using PMTDataAccess.Validations;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PMTDataAccess.Models
{
    public class ProjectMember
    {
        [Required]
        [BsonId]
        public string? MemberId { get; set; }

        [Required]
        [BsonElement("Name")]
        public string? Name { get; set; }

        [Required]
        [YearsOfExperienceValidation]
        public int Experience { get; set; }

        [Required]
        [SkillsValidation]
        public List<string>? Skills { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int AllocationPercentage { get; set; }

        [Required]
        [ProjectDateValidation]
        public DateTime StartDate { get; set; }

        [Required]
        [ProjectDateValidation]
        public DateTime EndDate { get; set; }
    }
}
