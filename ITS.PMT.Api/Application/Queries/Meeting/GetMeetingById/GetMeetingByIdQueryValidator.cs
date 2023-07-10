using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Meeting.GetMeetingById
{
    public class GetMeetingByIdQueryValidator : AbstractValidator<GetMeetingByIdQuery>
    {

        public GetMeetingByIdQueryValidator()
        {
            RuleFor(t => t.Id).NotEqual(0).WithMessage("Id can't be empty!");
        }
    }
}
