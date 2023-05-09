using PMTDataAccess.Models;
using MongoDB.Driver;

namespace PMTDataAccess.Data
{
    public interface IDbContext
    {
        IMongoCollection<ProjectMember> GetProjectMembersCollection<ProjectMember>();
        IMongoCollection<TaskMember> GetTaskMembersCollection<TaskMember>();
        IMongoCollection<ProjectTaskMember> GetProjectTaskCollection<ProjectTaskMember>();
        void DropCollection();
    }
}
