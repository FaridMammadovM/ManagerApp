using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Comment.UpdateComment
{
    public sealed class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(t => t.updateCommentDto.Id).NotEqual(0).WithMessage("Id cannot be null");
        }
    }
}
