using Manager.API.Models;

namespace Manager.API.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        ProjectMember AddProjectMember(ProjectMember projectMember);
        List<ProjectMember> GetAllProjectMembers();
        ProjectMember GetProjectMember(string id);
        void UpdateProjectMember(string id, ProjectMember projectMember);
    }
}
