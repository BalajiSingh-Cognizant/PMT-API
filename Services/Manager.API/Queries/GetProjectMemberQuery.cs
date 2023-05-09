using PMTDataAccess.Models;
using MediatR;

namespace Manager.API.Queries
{
    public class GetProjectMemberQuery : IRequest<List<ProjectMember>>
    {
    }
}
