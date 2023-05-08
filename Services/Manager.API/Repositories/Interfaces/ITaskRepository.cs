using Manager.API.Models;

namespace Manager.API.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        TaskMember GetTaskMember(string id);
        TaskMember AddTaskMember(TaskMember taskMember);
    }
}
