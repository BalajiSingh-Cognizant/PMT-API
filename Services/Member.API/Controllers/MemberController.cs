using MediatR;
using Member.API.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Member.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MemberController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("list/{id}/{taskName}")]
        public async Task<IActionResult> GetTaskAsync(string id, string taskName)
        {
            try
            {
                var projectTaskMember = await _mediator.Send(new GetProjectTaskMemberQuery(id, taskName));

                if (projectTaskMember == null)
                {
                    return BadRequest();
                }
                return Ok(projectTaskMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the task" + ex.Message);
            }
        }
    }
}
