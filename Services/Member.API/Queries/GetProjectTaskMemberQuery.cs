using MediatR;
using PMTDataAccess.Models;

namespace Member.API.Queries
{
    public class GetProjectTaskMemberQuery : IRequest<ProjectTaskMember>
    {
        public string MemberId { get; set; }
        public string TaskName { get; set; }
        public GetProjectTaskMemberQuery(string memberId, string taskName)
        {
            this.MemberId = memberId;
            this.TaskName = taskName;
        }
    }
}
