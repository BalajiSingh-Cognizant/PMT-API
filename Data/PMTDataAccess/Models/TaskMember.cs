using PMTDataAccess.Validations;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PMTDataAccess.Models
{
    public class TaskMember
    {
        [Required]
        [BsonId]
        public string? TaskId { get; set; }

        [Required]
        public string? MemberId { get; set; }

        [Required]
        public string? MemberName { get; set; }

        [Required]
        [BsonElement("Name")]
        public string? TaskName { get; set; }

        [Required]
        public string? Deliverables { get; set; }

        [Required]
        [TaskDateValidation]
        public DateTime StartDate { get; set; }

        [Required]
        [TaskDateValidation]
        public DateTime EndDate { get; set; }
    }
}
