using Manager.API.Commands;
using PMTDataAccess.Models;
using PMTDataAccess.Repositories.Interfaces;
using Manager.API.Utilities;
using MediatR;

namespace Manager.API.Handlers
{
    public class AssigningTaskCommandHandler : IRequestHandler<AssigningTaskCommand, TaskMember>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ISendAssigningTask _sendAssigningTask;
        private readonly IProjectRepository _projectRepository;

        public AssigningTaskCommandHandler(ITaskRepository taskRepository, IProjectRepository projectRepository, ISendAssigningTask sendAssigningTask)
        {
            _taskRepository = taskRepository;
            this._sendAssigningTask = sendAssigningTask;
            this._projectRepository = projectRepository;
        }

        public Task<TaskMember> Handle(AssigningTaskCommand request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                _taskRepository.AddTaskMember(request.TaskMemberDetails);
                var projectMember = this._projectRepository.GetProjectMember(request.TaskMemberDetails.MemberId);

                ProjectTaskMember projectTaskMember = new ProjectTaskMember
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
                    _sendAssigningTask.SendTask(projectTaskMember);
                }
                return request.TaskMemberDetails;
            });
        }
    }
}
