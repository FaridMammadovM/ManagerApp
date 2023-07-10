using ITS.PMT.Domain.Dto.CommentProjectDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.CommentProject.Create
{
    public class CreateCommentProjectCommand : IRequest<int>
    {
        public CreateCommentProjectDto createCommentDto { get; set; }
    }
}
