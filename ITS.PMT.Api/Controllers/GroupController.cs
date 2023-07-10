using ITS.PMT.Api.Application.Commands.RoleType.Create;
using ITS.PMT.Api.Application.Commands.RoleType.Delete;
using ITS.PMT.Api.Application.Commands.RoleType.Update;
using ITS.PMT.Api.Application.Queries.RoleType.GetAll;
using ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupPermissionById;
using ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupUserById;
using ITS.PMT.Api.Application.Queries.RoleType.GetById;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CheckAccess]

    public class GroupController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<GroupController> _logger;
        private readonly IMediator _mediator;

        public GroupController(IConfiguration configuration, ILogger<GroupController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }


        /// <summary>
        /// Creates role
        /// </summary>
        [HttpPost("CreateGroup")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateGroup([FromBody] CreateRoleTypeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully groupinformation.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed groupinformation.");


                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("groupcannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        /// <summary>
        /// Update role
        /// </summary>
        [HttpPut("UpdateGroup")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateGroup([FromBody] UpdateRoleTypeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Update successfully groupinformation.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Update failed groupinformation.");


                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("groupcannot updated");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        /// <summary>
        /// Delete role
        /// </summary>
        [HttpDelete("DeleteGroup")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteGroup([FromBody] DeleteRoleTypeCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Delete successfully groupinformation.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Delete failed groupinformation.");


                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("groupcannot deleted");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        /// <summary>
        /// getbyid group
        /// </summary>
        [HttpGet("GetGroupById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupById(GetByIdRoleTypeQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    _logger.LogInformation("Got successfully group from database.");
                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    Response response = new Response() { Result = "Null", Message = "Failed" };
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets all group data from database.
        /// </summary>
        [HttpGet("GetAllGroupName")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllGroupName()
        {
            try
            {
                var result = await _mediator.Send(new GetAllNameRoleTypeQuery());
                if (result != null)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

                    Response response = new Response() { Result = result, Message = "Project is null" };
                    return NotFound(response);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Gets all group data from database.
        /// </summary>
        [HttpGet("GetAllGroupPermissionById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllGroupPermissionById(GetAllGroupPermissionByIdQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

                    Response response = new Response() { Result = result, Message = "Project is null" };
                    return NotFound(response);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Gets all group data from database.
        /// </summary>
        [HttpGet("GetAllGroupUserById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllGroupUserById(GetAllGroupUserByIdQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

                    Response response = new Response() { Result = result, Message = "Project is null" };
                    return NotFound(response);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
