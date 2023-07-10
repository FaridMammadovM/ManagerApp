using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.CommentProject;
using ITS.PMT.Infrastructure.Repositories.CommentProjectRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.CommentProject.Create
{
    public sealed class CreateCommentProjectCommandHandler : IRequestHandler<CreateCommentProjectCommand, int>
    {
        private readonly ICommentProjectRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCommentProjectCommand> _validator;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CreateCommentProjectCommandHandler(ICommentProjectRepository commentRepository, IMapper mapper, IValidator<CreateCommentProjectCommand> validator, IHttpContextAccessor httpContextAccessor)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _validator = validator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Handle(CreateCommentProjectCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);

            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(authorizationHeader);

            var claims = decodedToken.Claims
                          .GroupBy(c => c.Type)
                          .ToDictionary(g => g.Key, g => g.First().Value);



            var result = await _commentRepository.CreateComment(_mapper.Map<CommentProjectModel>(request.createCommentDto));
            return result;
        }
    }
}
