using ITS.PMT.Api.Application.Commands.Project.UpdateAdditionallInfo;
using ITS.PMT.Api.Application.Queries.Project.GetAdditionallInfo;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITS.PMT.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [CheckAccess]

    public class ProjectAdditionallInfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProjectAdditionallInfoController> _logger;
        private readonly IMediator _mediator;


        public ProjectAdditionallInfoController(IConfiguration configuration, ILogger<ProjectAdditionallInfoController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get All addition info  of Project
        /// </summary>

        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAdditionallInfo(int projectId)
        {
            try
            {
                var result = await _mediator.Send(new GetAdditionallInfoQuery { ProjectId = projectId });
                if (result != null)
                {
                    _logger.LogInformation("Getting information of Project  successfully", result);

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Getting addition information of Project failed .", projectId);

                    Response response = new Response() { Result = result, Message = "getting Failed" };
                    return NotFound(response);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, projectId);
                return Problem(ex.Message);
            }
        }



        /// <summary>
        /// Update  addition info of project 
        /// </summary>

        [HttpPut]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAdditionallInfo([FromBody] UpdateAdditionalInfoCommand updateAdditionallInfoCommand)
        {
            try
            {
                var result = await _mediator.Send(updateAdditionallInfoCommand);
                if (result != 0)
                {
                    _logger.LogInformation("uptaded  successfully", result);

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("updated information failed .", updateAdditionallInfoCommand.updateAdditionallInfoDto.ProjectId);

                    Response response = new Response() { Result = result, Message = "Updated Failed" };
                    return NotFound(response);

                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, updateAdditionallInfoCommand.updateAdditionallInfoDto.ProjectId);
                return Problem(ex.Message);
            }
        }
    }
}
