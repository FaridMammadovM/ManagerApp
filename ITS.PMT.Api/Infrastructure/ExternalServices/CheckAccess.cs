using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace ITS.PMT.Api.Infrastructure.ExternalServices
{
    public class CheckAccess : ActionFilterAttribute
    {
        private readonly string _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("CentralizedAuth")["TokenIsValid"];

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (SkipAuthorization(actionContext)) return;

            if (string.IsNullOrEmpty(actionContext.HttpContext.Request.Headers["Authorization"]))
            {
                actionContext.Result = new StatusCodeResult(401);
            }
            else
            {
                var token = actionContext.HttpContext.Request.Headers["Authorization"];
                AuthenticationServices service = new AuthenticationServices();
                var check = service.TokenIsValid(token);
                if (!check)
                {
                    actionContext.Result = new StatusCodeResult(401);
                }
            }
        }
        private bool SkipAuthorization(ActionExecutingContext actionContext)
        {
            var controllerActionDescriptor = actionContext.ActionDescriptor as ControllerActionDescriptor;
            return controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                    .Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)));
        }
    }

}

