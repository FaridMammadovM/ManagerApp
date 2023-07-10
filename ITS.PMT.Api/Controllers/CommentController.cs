using ITS.PMT.Api.Application.Commands.Comment;
using ITS.PMT.Api.Application.Commands.Comment.UpdateComment;
using ITS.PMT.Api.Application.Queries.MeetingComment;
using ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentAgreedParticipant;
using ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentNotAgreedParticipant;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using ITS.PMT.Domain.Dto.CommentDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Controllers
{
    /// <summary>
    /// Bu kontroller 2-ci ekranda olan sonuncu Rəy bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class CommentController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<CommentController> _logger;
        private readonly IMediator _mediator;

        public CommentController(IConfiguration configuration, ILogger<CommentController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates Comment
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully Comment information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed Comment information.");

                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("Comment cannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        /// <summary>
        /// Get MeetingComment from database by MeetingId.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces("application/json")]

        public async Task<ActionResult<GetCommentByMeetingIdDto>> GetMeetingCommentByMeetingId(int meetingId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentByMeetingIdQuery { MeetingId = meetingId });
                _logger.LogInformation($"Get Meeting comment succesfully {meetingId}");


                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Comment is not found!";
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
        /// Gets agreed participants from database.
        /// </summary>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetParticipantByMeetingCommentId(int MeetingCommentId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentAgreedParticipantQuery { MeetingCommentId = MeetingCommentId });
                _logger.LogInformation($"Get agreed participant information succesfully {MeetingCommentId}");


                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Comment agreed participant is not found!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetEmployeeByRoleId error {MeetingCommentId}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }
        /// <summary>
        /// Gets not agreed participants from database.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetNotParticipantByMeetingCommentId(int MeetingCommentId)
        {
            try
            {
                var result = await _mediator.Send(new GetCommentNotAgreedParticipantQuery { MeetingCommentId = MeetingCommentId });
                _logger.LogInformation($"Get not agreed participant information succesfully {MeetingCommentId}");


                Response response = new Response();
                if (result.Count == 0)
                {
                    response.Result = null;
                    response.Message = "Comment not agreed participant is not found!";
                    return NotFound(response);
                }
                response.Result = result;
                response.Message = "Success";


                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetEmployeeByRoleId error {MeetingCommentId}");
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Update Comment and Agree Participants  in Meeting
        /// </summary>

        [HttpPut]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            try
            {
                var result = await _mediator.Send(updateCommentCommand);
                if (result != 0)
                {
                    Response response = new Response() { Message = "Success" };
                    _logger.LogInformation("Update successfully Task information.");
                    return Ok(response);
                }
                else
                {

                    Response response = new Response() { Message = "Failed" };
                    _logger.LogError($"Update Failed in commentId: {updateCommentCommand.updateCommentDto.Id}");
                    return NotFound(response);
                }


            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, $"Error  comment id:{updateCommentCommand.updateCommentDto.Id}");
                return Problem(ex.Message);
            }
        }


    }
}
