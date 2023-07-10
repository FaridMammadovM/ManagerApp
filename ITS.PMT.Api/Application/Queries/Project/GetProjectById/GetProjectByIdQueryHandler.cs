using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetProjectById
{
    public sealed class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, List<GetProjectByIdDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetProjectByIdQuery> _validator;

        public GetProjectByIdQueryHandler(IProjectRepository projectRepository, IMapper mapper, IValidator<GetProjectByIdQuery> validator)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<List<GetProjectByIdDto>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _projectRepository.GetProjectById(request.Id);
            return _mapper.Map<List<GetProjectByIdDto>>(result); ;
        }
    }
}
