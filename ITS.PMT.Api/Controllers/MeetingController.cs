using ITS.PMT.Api.Application.Commands.Meeting.CreateMeeting;
using ITS.PMT.Api.Application.Commands.Meeting.DeleteMeeting;
using ITS.PMT.Api.Application.Commands.Meeting.UpdateMeeting;
using ITS.PMT.Api.Application.Queries.Meeting.GetAllMeetings;
using ITS.PMT.Api.Application.Queries.Meeting.GetMeetingById;
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
    /// Bu kontroller 2-ci ekranda olan  Iclas bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class MeetingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TaskController> _logger;
        private readonly IMediator _mediator;

        public MeetingController(IConfiguration configuration, ILogger<TaskController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creating Meeting
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateMeeting([FromBody] CreateMeetingCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully Meeting information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("CreateMeeting failed.");

                    Response response = new Response() { Result = null, Message = "Failed." };
                    return Problem("Meeting cannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        /// <summary>
        /// Updates Meeting data in database.
        /// </summary>
        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateMeeting([FromBody] UpdateMeetingCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result == 1)
                {
                    _logger.LogInformation("Update successfully Meeting information.");
                    Response response = new Response() { Result = null, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("UpdateMeeting failed.");

                    Response response = new Response() { Result = null, Message = "Failed." };
                    return Problem("Meeting cannot updated");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// GetAllMeetings  from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllMeetings()
        {
            try
            {
                var result = await _mediator.Send(new GetAllMeetingsQuery());
                _logger.LogInformation("GetAllMeetings successfully");
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
        /// Delete Meeting  from database.
        /// </summary>
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteMeeting([FromBody] DeleteMeetingCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
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
        /// Get Meeting from database by id.
        /// </summary>

        [HttpGet()]
        [Produces("application/json")]

        public async Task<IActionResult> GetMeetingById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetMeetingByIdQuery { Id = id });
                _logger.LogInformation("Got successfully Meeting from database.");

                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Meeting is not found!";
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
