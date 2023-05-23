using Manager.API.Commands;
using PMTDataAccess.Models;
using Manager.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Manager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ManagerController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("GetMembers")]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var projectMembers = await _mediator.Send(new GetProjectMemberQuery());
                return Ok(projectMembers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Database error");
            }
        }

        [HttpPost]
        [Route("AddMember")]
        public async Task<IActionResult> AddMember(ProjectMember pm)
        {
            try
            {
                if (pm == null)
                    return BadRequest();

                var projectMember = await _mediator.Send(new AddProjectMemberCommand(pm));

                if (projectMember == null)
                {
                    return BadRequest();
                }

                //return CreatedAtAction($"api/member/{pm.MemberId}", projectMember);
                return Ok(projectMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new team member" + ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAllocation/{percentage}")]
        public async Task<IActionResult> UpdateAllocation(string percentage)
        {
            try
            {
                var projectMembers = await _mediator.Send(new UpdateAllocationCommand(Int32.Parse(percentage)));

                if (projectMembers == null)
                {
                    return BadRequest();
                }

                return Ok(projectMembers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + ex.Message);
            }
        }

        [HttpPost]
        [Route("AssignTask")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AssignTask(TaskMember task)
        {
            try
            {
                if (task == null)
                    return BadRequest();

                var projectMember = await _mediator.Send(new AssigningTaskCommand(task));

                if (projectMember == null)
                {
                    return BadRequest();
                }
                //return CreatedAtAction($"/member/{task.MemberId}", projectMember);
                return Ok(projectMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error assigning a new task to team member" + ex.Message);
            }
        }
    }
}
