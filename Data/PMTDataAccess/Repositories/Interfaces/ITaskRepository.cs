using PMTDataAccess.Models;

namespace PMTDataAccess.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        TaskMember GetTaskMember(string id);
        TaskMember AddTaskMember(TaskMember taskMember);
    }
}
