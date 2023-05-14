using MediatR;
using PMTDataAccess.Models;

namespace Member.API.Queries
{
    public class GetProjectTaskMemberQuery : IRequest<ProjectTaskMember>
    {
        public string MemberId { get; set; }
        public GetProjectTaskMemberQuery(string memberId)
        {
            this.MemberId = memberId;
        }
    }
}
