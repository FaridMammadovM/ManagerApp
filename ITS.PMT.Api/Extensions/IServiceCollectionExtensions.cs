﻿using Hellang.Middleware.ProblemDetails;
using ITS.PMT.Api.Infrastructue.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ITS.PMT.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedProblemDetails(this IServiceCollection services)
        {

            services.AddProblemDetails(opts =>
            {
                opts.Map<Exception>(ex =>
                {
                    int statusCode = 500;
                    switch (ex)
                    {
                        case ApiException exception:
                            statusCode = exception.StatusCode;
                            break;
                        case HttpResponseException exception:
                            statusCode = exception.StatusCode;
                            break;
                        default:
                            break;
                    }



                    return new Microsoft.AspNetCore.Mvc.ProblemDetails
                    {
                        Detail = ex.Message,
                        Status = statusCode
                    };
                });
            });



            return services;
        }
    }
}
