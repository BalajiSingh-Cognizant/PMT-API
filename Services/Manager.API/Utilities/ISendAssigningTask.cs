using PMTDataAccess.Models;

namespace Manager.API.Utilities
{
    public interface ISendAssigningTask
    {
        void SendTask(ProjectTaskMember projectTaskMember);
    }
}
