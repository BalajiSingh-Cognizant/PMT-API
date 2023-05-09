using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PMTDataAccess.Models
{
    public class ProjectTaskMember
    {
        [Required]
        [BsonId]
        public string ProjectTaskMemberId { get; set; }
        [Required]
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string TaskName { get; set; }
        public string Deliverables { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskEndDate { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string> Skills { get; set; }
        public string Description { get; set; }
        public int AllocationPercentage { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}
