using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Protocol.GetProtocolsByMeetingId
{
    public sealed class GetProtocolsByMeetingIdQueryValidator : AbstractValidator<GetProtocolsByMeetingIdQuery>
    {
        public GetProtocolsByMeetingIdQueryValidator()
        {

            RuleFor(x => x.MeetingId).NotEqual(0).WithMessage("MeetingId is not empty");
        }
    }
}
