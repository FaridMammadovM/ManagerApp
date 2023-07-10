using AutoMapper;
using FluentValidation;
using ITS.PMT.Api.Application.Queries.MeetingComment;
using ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Domain.Dto.CommentDtos
{
    public class GetCommentByMeetingIdHandler : IRequestHandler<GetCommentByMeetingIdQuery, List<GetCommentByMeetingIdDto>>
    {
        private readonly ICommentRepository _meetingCommentRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetCommentByMeetingIdQuery> _validator;

        public GetCommentByMeetingIdHandler(ICommentRepository meetingCommentRepository, IMapper mapper, IValidator<GetCommentByMeetingIdQuery> validator)
        {
            _meetingCommentRepository = meetingCommentRepository;
            _mapper = mapper;
            _validator = validator;
        }



        public async Task<List<GetCommentByMeetingIdDto>> Handle(GetCommentByMeetingIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _meetingCommentRepository.GetMeetingCommentByMeetingId(request.MeetingId);
            return _mapper.Map<List<GetCommentByMeetingIdDto>>(result);
        }


    }
}