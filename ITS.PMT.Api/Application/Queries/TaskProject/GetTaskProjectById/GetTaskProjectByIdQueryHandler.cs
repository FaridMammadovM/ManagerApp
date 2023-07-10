using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.TaskProjectDtos;
using ITS.PMT.Infrastructure.Repositories.TaskProjectRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.TaskProject.GetTaskProjectById
{
    public sealed class GetTaskProjectByIdQueryHandler : IRequestHandler<GetTaskProjectByIdQuery, TaskProjectByIdDto>
    {
        private readonly ITaskProjectRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetTaskProjectByIdQuery> _validator;
        public GetTaskProjectByIdQueryHandler(ITaskProjectRepository taskRepository, IMapper mapper, IValidator<GetTaskProjectByIdQuery> validator)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<TaskProjectByIdDto> Handle(GetTaskProjectByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _taskRepository.GetById(request.Id);

            if (result.LastDeadline.ToString() == "1/1/0001 12:00:00 AM")
            {
                result.LastDeadline = null;
            }
            if (result.Deadline.ToString() == "1/1/0001 12:00:00 AM")
            {
                result.LastDeadline = null;
            }


            return _mapper.Map<TaskProjectByIdDto>(result); ;
        }
    }
}
