using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;
using Manager.API.Queries;
using MediatR;

namespace Manager.API.Handlers
{
    public class GetProjectMemberQueryHandler : IRequestHandler<GetProjectMemberQuery, List<ProjectMember>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectMemberQueryHandler(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public Task<List<ProjectMember>> Handle(GetProjectMemberQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() => this._projectRepository.GetAllProjectMembers().OrderByDescending(pm => pm.Experience).ToList());
        }
    }
}
