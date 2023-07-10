using ITS.PMT.Domain.Dto.CommentDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Comment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public CreateCommentDto createCommentDto { get; set; }
    }
}
