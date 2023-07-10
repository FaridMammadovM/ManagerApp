using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.CommentProject
{
    public sealed class GetAllCommentProjectQueryValidator : AbstractValidator<GetAllCommentProjectQuery>
    {
        public GetAllCommentProjectQueryValidator()
        {
            RuleFor(t => t.Id).NotEqual(0).WithMessage("CommentId can't be empty!");

        }

    }
}
