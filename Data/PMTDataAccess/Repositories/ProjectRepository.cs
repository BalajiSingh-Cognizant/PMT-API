using PMTDataAccess.Data;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;
using MongoDB.Driver;

namespace PMTDataAccess.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMongoCollection<ProjectMember> _ProjectMemberCollection;
        public ProjectRepository(IDbContext dbContext)
        {
            _ProjectMemberCollection = dbContext.GetProjectMembersCollection<ProjectMember>();
        }

        public ProjectMember AddProjectMember(ProjectMember projectMember)
        {
            _ProjectMemberCollection.InsertOne(projectMember);
            return projectMember;
        }

        public List<ProjectMember> GetAllProjectMembers()
        {
            return _ProjectMemberCollection.Find(_ => true).ToList();
        }

        public ProjectMember GetProjectMember(string id)
        {
            return _ProjectMemberCollection.Find(x => x.MemberId == id).FirstOrDefault();
        }

        public void UpdateProjectMember(string id, ProjectMember projectMember)
        {
            _ProjectMemberCollection.ReplaceOneAsync(x => x.MemberId == id, projectMember);
        }
    }
}
