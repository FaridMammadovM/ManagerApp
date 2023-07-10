using ITS.PMT.Api.Application.Commands.Auth.AddGroupUser;
using ITS.PMT.Api.Application.Commands.Auth.DeleteGroupUser;
using ITS.PMT.Api.Application.Commands.Auth.GroupPermission.AddRolePermission;
using ITS.PMT.Api.Application.Commands.Auth.GroupPermission.DeleteGroupPermission;
using ITS.PMT.Api.Application.Commands.Auth.UserPermission.AddUserPermission;
using ITS.PMT.Api.Application.Commands.Auth.UserPermission.DeleteUserPermission;
using ITS.PMT.Api.Application.Queries.Auth;
using ITS.PMT.Api.Infrastructure.ExternalServices;
using ITS.PMT.Api.Infrastructure.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CheckAccess]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly IMediator _mediator;

        public AuthController(IConfiguration configuration, ILogger<AuthController> logger, IMediator mediator)
        {
            _configuration = configuration;
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Check Token
        /// </summary>
        [HttpPost("TokenIsValid")]
        [Produces("application/json")]
        public async Task<IActionResult> TokenIsValid()
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];

                string tokenIsValid = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("CentralizedAuth")["TokenIsValid"];


                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.PostAsync(tokenIsValid + "?token=" + token, null);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Token is true");
                }
                else
                {
                    return NotFound("Token is false");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpPost("GetAllPermissionByUser")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllPermissionByUser()
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                var tokenHandler = new JwtSecurityTokenHandler();
                var decodedToken = tokenHandler.ReadJwtToken(token);

                var claims = new Dictionary<string, string>();

                foreach (var claim in decodedToken.Claims)
                {
                    if (!claims.ContainsKey(claim.Type))
                    {
                        claims.Add(claim.Type, claim.Value);
                    }
                }

                string getUserRolesByIdUrl = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("CentralizedAuth")["GetUserRolesById"];

                HttpClient client = new HttpClient();

                string userId = claims["userid"];

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // Bearer token'ı ayarla

                string url = string.Format(getUserRolesByIdUrl + "/{0}", userId); // URL'deki {0} yerine userId

                HttpResponseMessage responseGet = await client.GetAsync(url); // GET isteyi
                string responseBody = await responseGet.Content.ReadAsStringAsync();

                var json = JsonConvert.DeserializeObject<dynamic>(responseBody);

                string finValue = json.data.fin;

                GetAllPermissionByUserQuery query = new GetAllPermissionByUserQuery();
                query.FinNumber = finValue;
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


        [HttpPost("AddGroupPermissions")]
        [Produces("application/json")]
        public async Task<IActionResult> AddGroupPermissions([FromBody] AddGroupPermissionCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully role information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed role information.");


                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("Role cannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpDelete("DeleteGroupPermissions")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteGroupPermissions([FromBody] DeleteGroupPermissionCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Delete successfully groupinformation.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Delete failed groupinformation.");

                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("groupcannot deleted");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        [HttpPost("AddGroupUser")]
        [Produces("application/json")]
        public async Task<IActionResult> AddGroupUser([FromBody] AddGroupUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully role information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed role information.");


                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("Role cannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }


        [HttpDelete("DeleteGroupUser")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteGroupUser([FromBody] DeleteGroupUserCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Delete successfully groupinformation.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Delete failed groupinformation.");

                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("groupcannot deleted");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }

        [HttpPost("AddUserPermission")]
        [Produces("application/json")]
        public async Task<IActionResult> AddUserPermission([FromBody] AddUserPermissionCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Added successfully role information.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Added failed role information.");


                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("Role cannot created");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);

            }
        }



        [HttpDelete("DeleteUserPermission")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteUserPermission([FromBody] DeleteUserPermissionCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result != 0)
                {
                    _logger.LogInformation("Delete successfully groupinformation.");

                    Response response = new Response() { Result = result, Message = "Success" };
                    return Ok(response);
                }
                else
                {
                    _logger.LogError("Delete failed groupinformation.");

                    Response response = new Response() { Result = null, Message = "Failed" };
                    return NotFound("groupcannot deleted");
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
