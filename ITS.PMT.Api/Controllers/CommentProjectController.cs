using ITS.PMT.Api.Application.Commands.CommentProject.Create;
using ITS.PMT.Api.Application.Queries.CommentProject;
using ITS.PMT.Api.Hubs;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Controllers
{

    /// <summary>
    /// Bu kontroller proyektde comment  bildirmek üçün yaradılıb.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class CommentProjectController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CommentProjectController> _logger;
        private readonly IMediator _mediator;
        private readonly IHubContext<MyHub> _hubContext;
        private readonly MyBusiness _myBusiness;

        public CommentProjectController(IConfiguration configuration, ILogger<CommentProjectController> logger,
            IMediator mediator, IHubContext<MyHub> hubContext, MyBusiness myBusiness)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
            _hubContext = hubContext;
            _myBusiness = myBusiness;
        }

        /// <summary>
        /// Creates Comment
        /// </summary>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentProjectCommand command)
        {
            try
            {
                _myBusiness.SenMessageAsync("", command.createCommentDto.Note);
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
        /// Gets all comment data from database.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetAllCommentsById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetAllCommentProjectQuery { Id = id });

                _logger.LogInformation("Selected successfully Comments information.");

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
