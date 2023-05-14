using PMTDataAccess.Models;

namespace PMTDataAccess.Repositories.Interfaces
{
    public interface IProjectTaskRepository
    {
        ProjectTaskMember ShowProjectTaskMember(string id);
        ProjectTaskMember AddProjectTaskMember(ProjectTaskMember taskMember);
    }
}
