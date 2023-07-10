using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentAgreedParticipant
{
    public sealed class GetCommentAgreedParticipantQueryHandler : IRequestHandler<GetCommentAgreedParticipantQuery, List<GetCommentAgreedParticipantDto>>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<GetCommentAgreedParticipantQuery> _validator;
        private readonly ICommentRepository _MeetingCommentRepository;
        public GetCommentAgreedParticipantQueryHandler(ICommentRepository MeetingCommentRepository, IMapper mapper, IValidator<GetCommentAgreedParticipantQuery> validator)
        {
            _MeetingCommentRepository = MeetingCommentRepository;
            _validator = validator;
            _mapper = mapper;
        }



        public async Task<List<GetCommentAgreedParticipantDto>> Handle(GetCommentAgreedParticipantQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _MeetingCommentRepository.GetParticipantByMeetingId(request.MeetingCommentId);
            var result2 = _MeetingCommentRepository.GetNotParticipantByMeetingId(request.MeetingCommentId);
            return result; //_mapper.Map<List<GetMeetingCommentAgreedParticipantDto>>(result);
        }
    }
}
