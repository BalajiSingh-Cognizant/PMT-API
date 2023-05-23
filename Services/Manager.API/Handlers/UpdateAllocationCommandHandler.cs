using Manager.API.Commands;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;
using MediatR;

namespace Manager.API.Handlers
{
    public class UpdateAllocationCommandHandler : IRequestHandler<UpdateAllocationCommand, List<ProjectMember>>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateAllocationCommandHandler(IProjectRepository projectRepository)
        {
            this._projectRepository = projectRepository;
        }

        public Task<List<ProjectMember>> Handle(UpdateAllocationCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var projectMembers = this._projectRepository.GetAllProjectMembers().ToList();
                for (int i = 0; i < projectMembers.Count; i++)
                {
                    if (projectMembers[i].EndDate > DateTime.Now)
                    {
                        projectMembers[i].AllocationPercentage = request.NewAllocationPercentage;
                        this._projectRepository.UpdateProjectMember(projectMembers[i].MemberId, projectMembers[i]);
                    }
                    else
                    {
                        projectMembers[i].AllocationPercentage = 0;
                        this._projectRepository.UpdateProjectMember(projectMembers[i].MemberId, projectMembers[i]);
                    }
                }

                return projectMembers;
            });

        }
    }
}
