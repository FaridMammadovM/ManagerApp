using FluentValidation;
using ITS.PMT.Domain.Dto.CommentProjectDtos;
using ITS.PMT.Infrastructure.Repositories.CommentProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.CommentProject
{
    public sealed class GetAllCommentProjectQueryHandler : IRequestHandler<GetAllCommentProjectQuery, List<GetAllCommentProjectDto>>
    {

        private readonly ICommentProjectRepository _commentProjectRepository;
        private readonly IValidator<GetAllCommentProjectQuery> _validator;
        public GetAllCommentProjectQueryHandler(ICommentProjectRepository commentProjectRepository, IValidator<GetAllCommentProjectQuery> validator)
        {
            _commentProjectRepository = commentProjectRepository;
            _validator = validator;
        }

        public async Task<List<GetAllCommentProjectDto>> Handle(GetAllCommentProjectQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _commentProjectRepository.GetAllCommentProject(request.Id);
            return result;
        }
    }
}
