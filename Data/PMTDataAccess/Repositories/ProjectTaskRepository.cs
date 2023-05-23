using MongoDB.Driver;
using PMTDataAccess.Data;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;

namespace PMTDataAccess.Repositories
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly IMongoCollection<ProjectTaskMember> _ProjectTaskMemberCollection;
        public ProjectTaskRepository(IDbContext dbContext)
        {
            _ProjectTaskMemberCollection = dbContext.GetProjectTaskCollection<ProjectTaskMember>();
        }

        public ProjectTaskMember AddProjectTaskMember(ProjectTaskMember projectTaskMember)
        {
            _ProjectTaskMemberCollection.InsertOne(projectTaskMember);
            return projectTaskMember;
        }

        public ProjectTaskMember ShowProjectTaskMember(string id, string taskName)
        {
            return _ProjectTaskMemberCollection.Find(tm => tm.MemberId == id && tm.TaskName == taskName).FirstOrDefault();
        }
    }
}
