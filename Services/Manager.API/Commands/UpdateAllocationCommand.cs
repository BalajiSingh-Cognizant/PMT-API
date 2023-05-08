using Manager.API.Models;
using MediatR;

namespace Manager.API.Commands
{
    public class UpdateAllocationCommand : IRequest<List<ProjectMember>>
    {
    }
}
