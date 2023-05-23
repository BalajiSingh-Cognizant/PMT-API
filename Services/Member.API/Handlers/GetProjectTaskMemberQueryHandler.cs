using MediatR;
using Member.API.Queries;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;

namespace Member.API.Handlers
{
    public class GetProjectTaskMemberQueryHandler : IRequestHandler<GetProjectTaskMemberQuery, ProjectTaskMember>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public GetProjectTaskMemberQueryHandler(IProjectTaskRepository showProjectTaskRepository)
        {
            this._projectTaskRepository = showProjectTaskRepository;
        }

        public Task<ProjectTaskMember> Handle(GetProjectTaskMemberQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var projectMembers = this._projectTaskRepository.ShowProjectTaskMember(request.MemberId, request.TaskName);
                return projectMembers;
            });

        }
    }
}
