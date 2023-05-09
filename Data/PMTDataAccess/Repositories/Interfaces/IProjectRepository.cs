using PMTDataAccess.Models;

namespace PMTDataAccess.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        ProjectMember AddProjectMember(ProjectMember projectMember);
        List<ProjectMember> GetAllProjectMembers();
        ProjectMember GetProjectMember(string id);
        void UpdateProjectMember(string id, ProjectMember projectMember);
    }
}
