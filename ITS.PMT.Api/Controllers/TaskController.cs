using ITS.PMT.Api.Application.Commands.Task.CreateTask;
using ITS.PMT.Api.Application.Commands.Task.DeleteTask;
using ITS.PMT.Api.Application.Commands.Task.UpdateTask;
using ITS.PMT.Api.Application.Queries.Task.GetTaskByProjectId;
using ITS.PMT.Api.Application.Queries.Task.GetTasksByProjectIdForGanttChart;
using ITS.PMT.Api.Application.Queries.Team.GetTaskById;
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
    /// Bu kontroller 1-ci ekranda olan  Fəaliyyət Planı(task) bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class TaskController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<TaskController> _logger;
        private readonly IMediator _mediator;

        public TaskController(IConfiguration configuration, ILogger<TaskController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Created task.
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateTask(CreateTaskCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully Task information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed Task information.");

                    Response response = new Response() { Result = result, Message = "Failed" };
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
        /// Delete task  from database.
        /// </summary>
        /// 
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTaskCommand { Id = id });
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
        /// GetAllTaskByProjectId  from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllTasksByProjectId(int projectId)
        {
            try
            {
                var result = await _mediator.Send(new GetAllTaskByProjectIdQuery { ProjectId = projectId });
                _logger.LogInformation("GetAllTaskByProjectId successfully");

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
        /// Get Task from database by id.
        /// </summary>
        [HttpGet()]
        [Produces("application/json")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetTaskByIdQuery { Id = id });
                _logger.LogInformation("Got successfully Task from database.");

                Response response = new Response();
                if (result.Count == 0)
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



        [HttpPut]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateTask(UpdateTaskCommand updateTaskCommand)
        {
            try
            {
                var result = await _mediator.Send(updateTaskCommand);
                if (result != 0)
                {
                    Response response = new Response() { Result = result, Message = "Success" };
                    _logger.LogInformation("Update successfully Task information.");
                    return Ok(response);
                }
                else
                {

                    Response response = new Response() { Result = "null", Message = "Failed" };
                    _logger.LogError("Update Failed.");
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
        /// Get Task by project id for gantt chart from database 
        /// </summary>
        [HttpGet()]
        [Produces("application/json")]
        public async Task<IActionResult> GetTasksByProjectIdForGanttChart(int projectId)
        {
            try
            {
                var result = await _mediator.Send(new GetTasksByProjectIdForGanttChartQuery { ProjectId = projectId });
                _logger.LogInformation("Got successfully Task by project id for gantt chart from database .");

                Response response = new Response();
                if (result.Count == 0)
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


    }
}

