﻿using Autofac;
using ITS.PMT.Api.Application.Queries.Project.GetAllProjects;
using MediatR;
using System.Reflection;

namespace ITS.PMT.Api.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
               .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(GetAllProjectsQuery).GetTypeInfo().Assembly)
        .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });
        }
    }
}
