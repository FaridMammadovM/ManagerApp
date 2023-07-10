using ITS.PMT.Api.Application.Commands.TaskProject.ChangeStatus;
using ITS.PMT.Api.Application.Commands.TaskProject.Create;
using ITS.PMT.Api.Application.Commands.TaskProject.Delete;
using ITS.PMT.Api.Application.Commands.TaskProject.Update;
using ITS.PMT.Api.Application.Queries.TaskProject.GetAll;
using ITS.PMT.Api.Application.Queries.TaskProject.GetTaskProjectById;
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
    /// <summary>
    /// Bu kontroller lahiyəyə tapşırıq əlavə etmək üçün yaradılıb.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class TaskProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TaskProjectController> _logger;
        private readonly IMediator _mediator;

        public TaskProjectController(IConfiguration configuration, ILogger<TaskProjectController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates task
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateProjectTask([FromBody] CreateTaskProjectCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully task information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed task information.");

                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("Task cannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        /// <summary>
        /// Updates task.
        /// </summary>
        /// <returns></returns>

        [HttpPut]
        [Produces("application/json")]

        public async Task<IActionResult> UpdateProjectTask([FromBody] UpdateTaskProjectCommand update)
        {
            try
            {
                var result = await _mediator.Send(update);
                if (result != 0)
                {
                    _logger.LogInformation("Selected successfully task information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed task information.");

                    Response response = new Response() { Result = null, Message = "task is null" };
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
        /// Delete task  from database.
        /// </summary>
        /// 
        [HttpDelete]
        public async Task<IActionResult> DeleteProjectTask(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTaskProjectCommand { Id = id });
                _logger.LogInformation("Deleted successfully Task information.");
                Response response = new();
                if (result == 0)
                {
                    response.Result = null;
                    response.Message = "Task is not found";
                    return NotFound(response);
                }
                response.Result = null;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error {id}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }

        }


        /// <summary>
        /// Change status.
        /// </summary>
        /// 
        [HttpPut]
        [Produces("application/json")]

        public async Task<IActionResult> ChangeTaskProjectStatus(ChangeStatusTaskProjectCommand update)
        {
            try
            {
                var result = await _mediator.Send(update);
                if (result != 0)
                {
                    _logger.LogInformation("Selected successfully task information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed task information.");

                    Response response = new Response() { Result = null, Message = "task is null" };
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
        /// Get Task from database by id.
        /// </summary>
        [HttpGet()]
        [Produces("application/json")]
        public async Task<IActionResult> GetTaskProjectById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTaskProjectByIdQuery { Id = id });
                _logger.LogInformation("Got successfully Task from database.");

                Response response = new Response();
                if (result is null)
                {
                    response.Result = null;
                    response.Message = "Task is not found!";
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
        /// GetAllTaskByProjectId  from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllTaskProjectsByProjectId(int projectId)
        {
            try
            {
                var result = await _mediator.Send(new GetAllTaskProjectByProjectIdQuery { ProjectId = projectId });
                _logger.LogInformation("GetAllTaskByProjectId successfully");

                Response response = new Response();

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

    }
}

