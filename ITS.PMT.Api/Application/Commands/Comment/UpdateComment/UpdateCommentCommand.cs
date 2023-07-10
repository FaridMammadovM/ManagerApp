using MediatR;

namespace ITS.PMT.Api.Application.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommand : IRequest<int>
    {
        public UpdateCommentDto updateCommentDto { get; set; }


    }
}
