using ITS.PMT.Api.Application.Commands.MeetingParticipant.DeleteMeetingParticipant;
using ITS.PMT.Api.Application.Commands.MeetingParticipant.InsertParticipant;
using ITS.PMT.Api.Application.Commands.MeetingParticipant.SendMailParticipant;
using ITS.PMT.Api.Application.Queries.MeetingParticipant.GetParticipant;
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
    /// Bu kontroller 2-ci ekranda olan  Iştirakçı bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class MeetingParticipantController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MeetingParticipantController> _logger;
        private readonly IMediator _mediator;


        public MeetingParticipantController(IConfiguration configuration, ILogger<MeetingParticipantController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }


        /// <summary>
        ///  Insert participant to Meeting
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> InsertParticipant(InsertParticipantCommand insertParticipantCommand)
        {
            try
            {
                var result = await _mediator.Send(insertParticipantCommand);

                if (result != 0)
                {
                    Response response = new Response() { Result = result, Message = "Success" };
                    _logger.LogInformation(" successfully Create Participant.");
                    return Ok(response);
                }
                else
                {
                    _logger.LogInformation("Failed Add participant", insertParticipantCommand.MeetingId);
                    Response response = new Response() { Result = result, Message = "Failed" };
                    return NotFound("Insert Participant  failed.");

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Delete MeetingParticipant from database.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteMeetingParticipant(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteMeetingParticipantCommand { Id = id });
                _logger.LogInformation("Deleted successfully MeetingParticipant information.");
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
        /// Get MeetingParticipant from database by MeetingId.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetParticipantByMeetingId(int meetingId)
        {
            try
            {
                var result = await _mediator.Send(new MeetingParticipantQuery { MeetingId = meetingId });
                _logger.LogInformation($"Get successfully Participant information by {meetingId}");


                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Participant is not found!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetEmployeeByRoleId error {meetingId}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Send Mail and Decline mail (flag==1 send mail, flag=2 decline mail).
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> SendEmailsByMeetingId([FromQuery] int meetingId, int flag)
        {
            try
            {
                var result = await _mediator.Send(new SendMailParticipantCommand { MeetingId = meetingId, Flag = flag });
                _logger.LogInformation($"Get successfully Employee information by {meetingId}");
                Response response = new();
                if (result == 0)
                {
                    response.Result = null;
                    response.Message = "Employee or mail is not found!";
                    return NotFound(response);
                }
                response.Result = null;
                response.Message = "Success";


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetEmployeeByMeetingId error {meetingId}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
    }


}
