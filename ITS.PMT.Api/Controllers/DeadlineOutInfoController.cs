using ITS.PMT.Api.Application.Commands.DeadlineOutInfo.UpdateDeadlineOutInfo;
using ITS.PMT.Api.Application.Queries.DeadlineOutInfo.GetDeadlineOutInfoByProjectId;
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
    /// Bu kontroller 3-cü ekranda olan  gecikmələr bölməsində istifadə olunmalıdır.
    /// </summary>

    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class DeadlineOutInfoController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<DeadlineOutInfoController> _logger;
        private readonly IMediator _mediator;

        public DeadlineOutInfoController(IConfiguration configuration, ILogger<DeadlineOutInfoController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }




        /// <summary>
        /// Updates Deadline Out Info in database
        /// </summary>
        [HttpPut]
        [Produces("application/json")]


        public async Task<IActionResult> UpdateDeadlineOutInfo([FromBody] UpdateDeadlineOutInfoCommand updateDeadlineOutInfoCommand)
        {
            try
            {
                var result = await _mediator.Send(updateDeadlineOutInfoCommand);
                if (result == 1)
                {
                    _logger.LogInformation("Update successfully Deadline Out Info information.");
                    Response response = new Response() { Result = updateDeadlineOutInfoCommand.updateDeadlineOutInfoDto.ProjectId, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Update Deadline Out Info failed.");
                    Response response = new Response() { Result = null, Message = "Failed." };
                    return Problem("Deadline Out Info cannot updated");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Gets Deadline Out Info from database
        /// </summary>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetDeadlineOutInfoByProjectId(int projectId)
        {
            try
            {
                var result = await _mediator.Send(new GetDeadlineOutInfoByProjectIdQuery { ProjectId = projectId });
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully Deadline Out Info information by projectId.");

                    Response response = new Response() { Result = result, Message = "Succes" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Selected failed Deadline Oun Info information by projectId.");

                    Response response = new Response() { Result = null, Message = "DeadlineOutInfo is not found" };
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