using MediatR;
using PMTDataAccess.Models;

namespace Member.API.Commands
{
    public class AddProjectTaskMemberCommand : IRequest<ProjectTaskMember>
    {
        public ProjectTaskMember ProjectTaskMemberDetails { get; set; }
        public AddProjectTaskMemberCommand(ProjectTaskMember projectTaskMemberDetails)
        {
            this.ProjectTaskMemberDetails = projectTaskMemberDetails;
        }
    }
}
