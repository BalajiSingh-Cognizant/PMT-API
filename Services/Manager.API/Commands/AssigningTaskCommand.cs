using PMTDataAccess.Models;
using MediatR;

namespace Manager.API.Commands
{
    public class AssigningTaskCommand : IRequest<TaskMember>
    {
        public TaskMember TaskMemberDetails { get; set; }
        public AssigningTaskCommand(TaskMember taskMember)
        {
            this.TaskMemberDetails = taskMember;
        }
    }
}
