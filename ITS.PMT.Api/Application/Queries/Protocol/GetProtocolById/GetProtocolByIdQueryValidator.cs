using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.Protocol.GetProtocolById
{
    public sealed class GetProtocolByIdQueryValidator : AbstractValidator<GetProtocolByIdQuery>
    {
        public GetProtocolByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id is not empty");
        }
    }
}
