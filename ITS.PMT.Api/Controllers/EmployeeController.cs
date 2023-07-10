using ITS.PMT.Api.Application.Queries.Employee;
using ITS.PMT.Api.Application.Queries.Employee.GetAllEmployeePermission;
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
    [Route("api/[controller]")]
    [ApiController]
    [CheckAccess]

    public class EmployeeController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;

        public EmployeeController(IConfiguration configuration, ILogger<EmployeeController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Gets all employees data from database.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Produces("application/json")]

        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var result = await _mediator.Send(new GetAllEmployeeQuery());
                if (result.Count != 0)
                {
                    _logger.LogInformation("Selected successfully Employee information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Employee information.");

                    Response response = new Response() { Result = null, Message = "Employee is null" };
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
        /// Gets all employeeb by permission data from database.
        /// </summary>
        [HttpGet("GetAllEmployeePermissionById")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllEmployeePermissionById(GetAllEmployeePermissionQuery query)
        {
            try
            {
                var result = await _mediator.Send(query);
                if (result != null)
                {
                    _logger.LogInformation("Selected successfully Project information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);

                }
                else
                {
                    _logger.LogError("Selected failed Project information.");

                    Response response = new Response() { Result = result, Message = "Project is null" };
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
