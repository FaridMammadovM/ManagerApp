using Autofac;
using ITS.PMT.Infrastructure.Repositories.AdditionallInfoRepository;
using ITS.PMT.Infrastructure.Repositories.CommentProjectRepository;
using ITS.PMT.Infrastructure.Repositories.DeadlineOutInfoRepository;
using ITS.PMT.Infrastructure.Repositories.EmployeeRepository;
using ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository;
using ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository;
using ITS.PMT.Infrastructure.Repositories.MeetingRepository;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using ITS.PMT.Infrastructure.Repositories.ProtocolRepository;
using ITS.PMT.Infrastructure.Repositories.RoleTypePermisssionRepository;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using ITS.PMT.Infrastructure.Repositories.RoleTypeUserRepository;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using ITS.PMT.Infrastructure.Repositories.TaskRepository;
using ITS.PMT.Infrastructure.Repositories.TeamRepository;
using ITS.PMT.Infrastructure.Repositories.UserPermissionRepository;
using Microsoft.Extensions.Configuration;

namespace ITS.PMT.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Module
    {
        public IConfiguration Configuration { get; }
        public ApplicationModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProjectRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IProjectRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new TaskRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<ITaskRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new TeamRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<ITeamRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new MeetingRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IMeetingRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ParametricRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IParametricRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new MeetingCommentRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IMeetingCommentRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new ProtocolRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IProtocolRepository>();

            builder.Register(c => new MeetingParticipantRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IMeetingParticipantRepository>()
                .InstancePerLifetimeScope();


            builder.Register(c => new CommentRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<ICommentRepository>()
                .InstancePerLifetimeScope();

            builder.Register(c => new AdditionallinfoRepository(Configuration["ConnectionStrings:PmtAppCon"]))
                .As<IAdditionallInfoRepository>()
                .InstancePerLifetimeScope();


            builder.Register(c => new DeadlineOutInfoRepository(Configuration["ConnectionStrings:PmtAppCon"]))
               .As<IDeadlineOutInfoRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new EmployeeRepository(Configuration["ConnectionStrings:PmtAppCon"]))
               .As<IEmployeeRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new CommentProjectRepository(Configuration["ConnectionStrings:PmtAppCon"]))
               .As<ICommentProjectRepository>()
               .InstancePerLifetimeScope();

            builder.Register(c => new TaskProjectRepository(Configuration["ConnectionStrings:PmtAppCon"]))
              .As<ITaskProjectRepository>()
              .InstancePerLifetimeScope();

            builder.Register(c => new RoleTypeRepository(Configuration["ConnectionStrings:PmtAppCon"]))
              .As<IRoleTypeRepository>()
              .InstancePerLifetimeScope();

            builder.Register(c => new GroupPermisssionRepository(Configuration["ConnectionStrings:PmtAppCon"]))
              .As<IGroupPermisssionRepository>()
              .InstancePerLifetimeScope();

            builder.Register(c => new RoleTypeUserRepository(Configuration["ConnectionStrings:PmtAppCon"]))
              .As<IRoleTypeUserRepository>()
              .InstancePerLifetimeScope();

            builder.Register(c => new UserPermissionRepository(Configuration["ConnectionStrings:PmtAppCon"]))
             .As<IUserPermissionRepository>()
             .InstancePerLifetimeScope();



            //builder.Register(c =>
            //{
            //    //This resolves a new context that can be used later.
            //    var context = c.Resolve<IComponentContext>();
            //    var config = context.Resolve<MapperConfiguration>();
            //    return config.CreateMapper(context.Resolve);
            //}).As<IMapper>()
            //.InstancePerLifetimeScope();

        }
    }
}
