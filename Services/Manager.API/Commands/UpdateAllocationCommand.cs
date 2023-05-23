using PMTDataAccess.Models;
using MediatR;

namespace Manager.API.Commands
{
    public class UpdateAllocationCommand : IRequest<List<ProjectMember>>
    {
        public int NewAllocationPercentage { get; set; }
        public UpdateAllocationCommand(int percentage)
        {
            this.NewAllocationPercentage = percentage;
        }
    }
}
