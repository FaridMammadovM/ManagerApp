using ITS.PMT.Api.Application.Queries.MeetingTypes.GetMeetingTypes;
using ITS.PMT.Api.Application.Queries.Parametric.Category;
using ITS.PMT.Api.Application.Queries.Parametric.Employee.GetEmployee;
using ITS.PMT.Api.Application.Queries.Parametric.GetAllCategoryCountProject;
using ITS.PMT.Api.Application.Queries.Parametric.PM;
using ITS.PMT.Api.Application.Queries.Parametric.Priority;
using ITS.PMT.Api.Application.Queries.Parametric.Role.GetRole;
using ITS.PMT.Api.Application.Queries.Parametric.Status;
using ITS.PMT.Api.Application.Queries.Project.GetProjectNames;
using ITS.PMT.Api.Application.Queries.Stage;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Domain.Models.MeetingTypes;
using ITS.PMT.Domain.Models.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Controllers
{
    /// <summary>
    /// Bu kontroller 2-ci və 1-ci ekranda olan  Combolar üçün istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class ParametricController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ParametricController> _logger;
        private readonly IMediator _mediator;

        public ParametricController(IConfiguration configuration, ILogger<ParametricController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// GetAllRoles from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<RoleModel>>> GetAllRoles()
        {
            try
            {
                var result = await _mediator.Send(new GetAllRoleQuery());
                _logger.LogInformation("GetRole successfully Role information.");
                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        /// <summary>
        /// Gets all stage data from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllStage()
        {
            try
            {
                var result = await _mediator.Send(new GetStageQuery());
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully All Stage information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Selected failed Stage information.");

                    Response response = new Response() { Result = result, Message = "Stage is null" };
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
        /// Gets all status data from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllStatus()
        {
            try
            {
                var result = await _mediator.Send(new GetStatusQuery());
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully All Status information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Selected failed Status information.");

                    Response response = new Response() { Result = result, Message = "Stage is null" };
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
        /// Get Employee from database by RoleId.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<GetAllEmployeeDto>> GetEmployeeByRoleId(int roleId)
        {
            try
            {
                var result = await _mediator.Send(new GetEmployeeByRoleIdQuery { RoleId = roleId });
                _logger.LogInformation($"Get Employee information succesfully {roleId}");


                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Employee is not found!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetEmployeeByRoleId error {roleId}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Gets Project Names data from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetProjectNames()
        {
            try
            {
                var result = await _mediator.Send(new GetProjectNamesQuery());
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully Project names information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project names information.");

                    Response response = new Response() { Result = null, Message = "Project is null" };
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
        /// GetMeetingTypes from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<List<MeetingTypes>>> GetMeetingTypes()
        {
            try
            {
                var result = await _mediator.Send(new GetMeetingTypesQuery());
                _logger.LogInformation("GetMeetingTypes successfully  information.");
                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        /// <summary>
        /// Gets all category data from database.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var result = await _mediator.Send(new GetAllCategoryQuery());
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully Category information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Category information.");

                    Response response = new Response() { Result = null, Message = "Category is null" };
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
        /// Gets all priority data from database.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetAllPriority()
        {
            try
            {
                var result = await _mediator.Send(new GetAllPriorityQuery());
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully Priority information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Priority information.");

                    Response response = new Response() { Result = null, Message = "Priority is null" };
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
        /// Gets all PO data from database.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetAllPO()
        {
            try
            {
                var result = await _mediator.Send(new GetAllPOQuery());
                _logger.LogInformation("Selected successfully Priority information.");

                Response response = new Response() { Result = result, Message = "Success" };
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetAllCategoryCountProject()
        {
            try
            {
                var result = await _mediator.Send(new GetAllCategoryCountProjectQuery());
                if (result.Count != 0 || result.Count == 0)
                {
                    _logger.LogInformation("Selected successfully Category information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Category information.");

                    Response response = new Response() { Result = null, Message = "Category is null" };
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
