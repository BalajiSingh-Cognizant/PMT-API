using Manager.API.Models;

namespace Manager.API.Utilities
{
    public interface ISendAssigningTask
    {
        void SendTask(ProjectTaskMember projectTaskMember);
    }
}
