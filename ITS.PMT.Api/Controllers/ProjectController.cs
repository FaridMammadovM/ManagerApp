using ITS.PMT.Api.Application.Commands.Project.CreateProject;
using ITS.PMT.Api.Application.Commands.Project.DeleteProjectCommand;
using ITS.PMT.Api.Application.Commands.Project.UpdateProject;
using ITS.PMT.Api.Application.Commands.Project.UpdateProjectPriority;
using ITS.PMT.Api.Application.Queries.Project;
using ITS.PMT.Api.Application.Queries.Project.GetAll;
using ITS.PMT.Api.Application.Queries.Project.GetAllManagment;
using ITS.PMT.Api.Application.Queries.Project.GetAllProjectCountByCategoryWithMonth;
using ITS.PMT.Api.Application.Queries.Project.GetAllProjectName;
using ITS.PMT.Api.Application.Queries.Project.GetAllProjectNameByCategory;
using ITS.PMT.Api.Application.Queries.Project.GetAllProjects;
using ITS.PMT.Api.Application.Queries.Project.GetProjectById;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Controllers
{
    /// <summary>
    /// Bu kontroller 1-ci ekranda olan  Layihə bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class ProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProjectController> _logger;
        private readonly IMediator _mediator;

        public ProjectController(IConfiguration configuration, ILogger<ProjectController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }
        /// <summary>
        /// Add project to the database.
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Added successfully Project information.");
                Response response = new();
                if (result == 0)
                {
                    response.Result = null;
                    response.Message = "Database connection failed";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                //return Ok(response);
                return CreatedAtAction("GetProjectById", new { id = result });

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetProtocolsByMeetingId error {command}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }
        /// <summary>
        /// Get project by Id from database.
        /// </summary>

        [HttpGet(Name = "GetProjectById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetProjectByIdQuery { Id = id });
                if (result.Count() != 0)
                {
                    _logger.LogInformation("Got successfully Projectlist  from database.");
                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    Response response = new Response() { Result = "Null", Message = "Failed" };
                    _logger.LogError("Getting Project Failed.", $"{id}");
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
        /// Update Project  from database.
        /// </summary>
        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateProject([FromBody] UpdateProjectCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update successfully Project information.");
                Response response = new Response();
                if (result == 0)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return NotFound(response);
                }
                response.Result = null;
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
        /// Delete Project from database.
        /// </summary>
        [HttpDelete()]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteProjectCommand { Id = id });
                _logger.LogInformation("Deleted successfully Project information.");
                Response response = new Response();
                if (result == 0)
                {
                    response.Result = null;
                    response.Message = "Error occured!";
                    return BadRequest(response);
                }
                response.Result = null;
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
        /// Gets all project data from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllProject()
        {
            try
            {
                var result = await _mediator.Send(new GetProjectQuery());
                if (result.Count != 0 || result.Count == 0)
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
        /// Gets all projects data from database for 3th screen
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllProjects()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProjectsQuery());
                if (result.Count != 0 || result.Count == 0)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

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
        /// Gets all projects data from database for 1th screen
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllQuery());
                if (result.Count != 0 || result.Count == 0)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

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
        /// Gets all projects data from database for 1th screen
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllManagment(GetAllManagmentQuery data)
        {
            try
            {
                var result = await _mediator.Send(data);
                if (result.Count != 0 || result.Count == 0)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

                    Response response = new Response() { Result = null, Message = "Project is null" };
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
        /// Gets all projects names data from database for 1th screen
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllProjectName()
        {
            try
            {
                var result = await _mediator.Send(new GetAllProjectNameQuery());

                _logger.LogInformation("Selected successfully Project information.");

                Response response = new Response() { Result = result, Message = "Success" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Update Project  from database.
        /// </summary>
        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateProjectPriority([FromBody] UpdateProjectPriorityCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update successfully Project information.");
                Response response = new Response();
                response.Result = null;
                response.Message = "Success";
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
        public async Task<IActionResult> GetAllProjectNameByCategory(GetAllProjectNameByCategoryQuery data)
        {
            try
            {
                var result = await _mediator.Send(data);

                _logger.LogInformation("Selected successfully Project information.");

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
        public async Task<IActionResult> GetAllProjectCountByCategoryWithMonth(GetAllProjectCountByCategoryWithMonthQuery data)
        {
            try
            {
                var result = await _mediator.Send(data);

                _logger.LogInformation("Selected successfully Project information.");

                Response response = new Response() { Result = result, Message = "Success" };
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
