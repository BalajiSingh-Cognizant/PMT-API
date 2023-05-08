using Manager.API.Models;
using MongoDB.Driver;

namespace Manager.API.Data
{
    public interface IDbContext
    {
        IMongoCollection<ProjectMember> GetProjectMembersCollection<ProjectMember>();
        IMongoCollection<TaskMember> GetTaskMembersCollection<TaskMember>();
        IMongoCollection<ProjectTaskMember> GetProjectTaskCollection<ProjectTaskMember>();
        void DropCollection();
    }
}
