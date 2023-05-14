using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Member.API.Commands;
using PMTDataAccess.Models;

namespace Member.API.EventBusConsumer
{
    public class AssignTaskConsumer : IConsumer<AsssignTaskEvent>
    {
        private readonly IMediator _mediator;

        public AssignTaskConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AsssignTaskEvent> context)
        {
            ProjectTaskMember ptm = new ProjectTaskMember()
            {
                MemberId = context.Message.MemberId,
                MemberName = context.Message.MemberName,
                TaskName = context.Message.TaskName,
                Deliverables = context.Message.Deliverables,
                TaskStartDate = context.Message.TaskStartDate,
                TaskEndDate = context.Message.TaskEndDate,
                YearsOfExperience = context.Message.YearsOfExperience,
                Skills = context.Message.Skills,
                Description = context.Message.Description,
                AllocationPercentage = context.Message.AllocationPercentage,
                ProjectStartDate = context.Message.ProjectStartDate,
                ProjectEndDate = context.Message.ProjectEndDate,
                ProjectTaskMemberId = context.Message.MemberId+"-PTM",
            };
            var projectTaskMember = await _mediator.Send(new AddProjectTaskMemberCommand(ptm));
        }
    }
}
