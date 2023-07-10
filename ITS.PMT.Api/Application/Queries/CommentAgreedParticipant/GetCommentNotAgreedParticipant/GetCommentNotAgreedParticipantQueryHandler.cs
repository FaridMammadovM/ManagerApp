using AutoMapper;
using FluentValidation;
using ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentNotAgreedParticipant;
using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.CommentAgreedParticipant.CommentNotAgreedParticipant
{
    public sealed class GetCommentNotAgreedParticipantQueryHandler : IRequestHandler<GetCommentNotAgreedParticipantQuery, List<GetCommentNotAgreedParticipantDto>>
    {

        private readonly IMapper _mapper;
        private readonly IValidator<GetCommentNotAgreedParticipantQuery> _validator;
        private readonly ICommentRepository _meetingCommentRepository;
        public GetCommentNotAgreedParticipantQueryHandler(ICommentRepository meetingCommentRepository, IMapper mapper, IValidator<GetCommentNotAgreedParticipantQuery> validator)
        {
            _meetingCommentRepository = meetingCommentRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<List<GetCommentNotAgreedParticipantDto>> Handle(GetCommentNotAgreedParticipantQuery request, CancellationToken cancellationToken)
        {

            _validator.ValidateAndThrow(request);
            var result = await _meetingCommentRepository.GetNotParticipantByMeetingId(request.MeetingCommentId);
            return result; //_mapper.Map<List<GetCommentAgreedParticipantDto>>(result);
        }
    }
}
