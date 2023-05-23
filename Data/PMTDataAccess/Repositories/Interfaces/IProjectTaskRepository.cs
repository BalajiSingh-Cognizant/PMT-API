using PMTDataAccess.Models;

namespace PMTDataAccess.Repositories.Interfaces
{
    public interface IProjectTaskRepository
    {
        ProjectTaskMember ShowProjectTaskMember(string id, string taskName);
        ProjectTaskMember AddProjectTaskMember(ProjectTaskMember taskMember);
    }
}
