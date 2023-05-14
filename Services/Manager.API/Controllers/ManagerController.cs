﻿using Manager.API.Commands;
using PMTDataAccess.Models;
using Manager.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        [Route("GetMember")]
        public async Task<IActionResult> GetMember()
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

                return CreatedAtAction($"/member/{pm.MemberId}", projectMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new team member" + ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAllocation()
        {
            try
            {
                var projectMembers = await _mediator.Send(new UpdateAllocationCommand());

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



                return CreatedAtAction($"/member/{task.MemberId}", projectMember);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error assigning a new task to team member" + ex.Message);
            }
        }
    }
}
