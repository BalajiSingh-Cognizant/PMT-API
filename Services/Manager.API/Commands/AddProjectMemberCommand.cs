using PMTDataAccess.Models;
using MediatR;

namespace Manager.API.Commands
{
    public class AddProjectMemberCommand : IRequest<ProjectMember>
    {
        public ProjectMember ProjectMemberDetails { get; set; }
        public AddProjectMemberCommand(ProjectMember projectMemberDetails)
        {
            this.ProjectMemberDetails = projectMemberDetails;
        }
    }
}
