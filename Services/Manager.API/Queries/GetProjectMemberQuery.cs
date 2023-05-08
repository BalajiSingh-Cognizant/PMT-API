using Manager.API.Models;
using MediatR;

namespace Manager.API.Queries
{
    public class GetProjectMemberQuery : IRequest<List<ProjectMember>>
    {
    }
}
