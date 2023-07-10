using ITS.PMT.Api.Application.Commands.Team;
using ITS.PMT.Api.Application.Commands.Team.DeleteTeam;
using ITS.PMT.Api.Application.Queries.Team;
using ITS.PMT.Api.Application.Queries.Team.GetTeam;
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
    /// Bu kontroller 1-ci ekranda olan  Komanda bölməsində istifadə olunmalıdır.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class TeamController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TeamController> _logger;
        private readonly IMediator _mediator;

        public TeamController(IConfiguration configuration, ILogger<TeamController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets  team  data from database by projectId.
        /// </summary>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetTeamByProjectId(int projectId)
        {
            try
            {
                var result = await _mediator.Send(new GetTeamByProjectIdQuery { ProjectId = projectId });
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully Team information by projectId.");

                    Response response = new Response() { Result = result, Message = "Succes" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Selected failed Team information by projectId.");

                    Response response = new Response() { Result = result, Message = "Team is not found" };
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
        /// Deletes team from database.
        /// </summary>
        /// 
        [HttpDelete]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTeamCommand { Id = id });
                _logger.LogInformation("Deleted successfully Team information.");
                Response response = new();
                if (result == 0)
                {
                    response.Result = null;
                    response.Message = "Team is not found";
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

        [HttpPost]
        [Produces("application/json")]

        public async Task<IActionResult> CreateTeam(CreateTeamCommand CreateTeamCommand)
        {
            try
            {
                var result = await _mediator.Send(CreateTeamCommand);

                if (result != 0)
                {
                    Response response = new Response() { Result = result, Message = "Success" };
                    _logger.LogInformation(" successfully Create Team .");
                    return Ok(response);
                }
                else
                {
                    _logger.LogInformation("Failed Add Team");
                    Response response = new Response() { Result = result, Message = "Failed" };
                    return NotFound("Team can not created");

                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetTeamForComboByProjectId(int projectId)
        {

            try
            {

                var result = _mediator.Send(new GetTeamForComboQuery() { Projectid = projectId });


                if (result != null)
                {
                    _logger.LogInformation("Getting team list for combo successfully  .");
                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Getting team list for combo failed");
                    Response response = new Response() { Result = "null", Message = "Failed" };
                    return NotFound("Team not found");
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
