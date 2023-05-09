using Manager.API.Commands;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;
using MediatR;

namespace Manager.API.Handlers
{
    public class AddProjectMemberCommandHandler : IRequestHandler<AddProjectMemberCommand, ProjectMember>
    {
        private readonly IProjectRepository _projectRepository;

        public AddProjectMemberCommandHandler(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }
        public Task<ProjectMember> Handle(AddProjectMemberCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                this._projectRepository.AddProjectMember(request.ProjectMemberDetails);

                return request.ProjectMemberDetails;
            });
        }
    }
}
