using ITS.PMT.Api.Application.Commands.Protocol.CreateProtocol;
using ITS.PMT.Api.Application.Commands.Protocol.DeleteProtocol;
using ITS.PMT.Api.Application.Commands.Protocol.UpdateProtocol;
using ITS.PMT.Api.Application.Queries.Protocol.GetProtocolById;
using ITS.PMT.Api.Application.Queries.Protocol.GetProtocolsByMeetingId;
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
    /// Bu kontroller 2-ci ekranda olan  Protokol bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class ProtocolController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProtocolController> _logger;
        private readonly IMediator _mediator;

        public ProtocolController(ILogger<ProtocolController> logger, IMediator mediator, IConfiguration configuration)
        {
            _logger = logger;
            _mediator = mediator;
            _configuration = configuration;
        }
        /// <summary>
        /// Update Protocol  from database.
        /// </summary>
        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateProtocol([FromBody] UpdateProtocolCommand command)
        {

            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Update successfully Project information.");
                Response response = new();
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
        /// Gets protocols from database by MeetingId.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetProtocolsByMeetingId(int meetingId)
        {
            try
            {
                var result = await _mediator.Send(new GetProtocolsByMeetingIdQuery { MeetingId = meetingId });
                _logger.LogInformation($"GetProtocolsByMeetingId successfully {meetingId}");

                Response response = new();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Protocol is not found!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"GetProtocolsByMeetingId error {meetingId}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        ///  Insert Protocol to the database.
        /// </summary>w

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateProtocol([FromBody] CreateProtocolCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Added successfully Protocol information.");
                Response response = new();
                if (result == 1)
                {
                    return Problem("Creating failed");
                }
                response.Result = null;
                response.Message = "Success";
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError("Protocol doesn't created!");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        /// <summary>
        /// Delete Protocol  from database.
        /// </summary>
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteProtocol(DeleteProtocolCommand deleteProtocolCommand)
        {
            try
            {
                var result = await _mediator.Send(deleteProtocolCommand);

                if (result != 0)
                {
                    Response response = new Response() { Result = null, Message = "Success" };
                    _logger.LogInformation(" successfully deleted .");
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Failed delete protocol");
                    Response response = new Response() { Result = null, Message = "Deleting failed" };
                    return Problem("Failed delete protocol");

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// GetProtocolById from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> GetProtocolById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetProtocolByIdQuery { Id = id });
                _logger.LogInformation("GetProtocolsById successfully");
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
    }
}
