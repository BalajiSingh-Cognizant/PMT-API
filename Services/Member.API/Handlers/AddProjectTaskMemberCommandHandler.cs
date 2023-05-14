using MediatR;
using Member.API.Commands;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;

namespace Member.API.Handlers
{
    public class AddProjectTaskMemberCommandHandler : IRequestHandler<AddProjectTaskMemberCommand, ProjectTaskMember>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public AddProjectTaskMemberCommandHandler(IProjectTaskRepository projectTaskRepository)
        {
            this._projectTaskRepository = projectTaskRepository;
        }
        public Task<ProjectTaskMember> Handle(AddProjectTaskMemberCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                this._projectTaskRepository.AddProjectTaskMember(request.ProjectTaskMemberDetails);

                return request.ProjectTaskMemberDetails;
            });
        }
    }
}
