using Manager.API.Commands;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;
using Manager.API.Utilities;
using MediatR;
using MassTransit;
using EventBus.Messages.Events;

namespace Manager.API.Handlers
{
    public class AssigningTaskCommandHandler : IRequestHandler<AssigningTaskCommand, TaskMember>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ISendAssigningTask _sendAssigningTask;
        private readonly IProjectRepository _projectRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public AssigningTaskCommandHandler(ITaskRepository taskRepository, 
            IProjectRepository projectRepository, 
            ISendAssigningTask sendAssigningTask,
            IPublishEndpoint publishEndpoint)
        {
            this._taskRepository = taskRepository;
            this._sendAssigningTask = sendAssigningTask;
            this._projectRepository = projectRepository;
            this._publishEndpoint = publishEndpoint;
        }

        public Task<TaskMember> Handle(AssigningTaskCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _taskRepository.AddTaskMember(request.TaskMemberDetails);
                var projectMember = this._projectRepository.GetProjectMember(request.TaskMemberDetails.MemberId);

                AsssignTaskEvent projectTaskMember = new AsssignTaskEvent
                {
                    MemberId = projectMember.MemberId,
                    MemberName = projectMember.Name,
                    TaskName = request.TaskMemberDetails.TaskName,
                    AllocationPercentage = projectMember.AllocationPercentage,
                    Deliverables = request.TaskMemberDetails.Deliverables,
                    TaskStartDate = request.TaskMemberDetails.StartDate,
                    TaskEndDate = request.TaskMemberDetails.EndDate,
                    ProjectStartDate = projectMember.StartDate,
                    ProjectEndDate = projectMember.EndDate
                };

                if (_sendAssigningTask != null)
                {
                    _publishEndpoint.Publish(projectTaskMember);
                }
                return request.TaskMemberDetails;
            });
        }
    }
}
