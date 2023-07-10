using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.DeleteMeetingParticipant
{
    public class DeleteMeetingParticipantCommandHandler : IRequestHandler<DeleteMeetingParticipantCommand, int>
    {
        private readonly IMeetingParticipantRepository _meetingParticipantRepository;
        private readonly IValidator<DeleteMeetingParticipantCommand> _validator;
        public DeleteMeetingParticipantCommandHandler(IMeetingParticipantRepository meetingParticipantRepository, IValidator<DeleteMeetingParticipantCommand> validator)
        {
            _meetingParticipantRepository = meetingParticipantRepository;
            _validator = validator;
        }
        public Task<int> Handle(DeleteMeetingParticipantCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = _meetingParticipantRepository.DeleteMeetingParticipant(request.Id);
            return result;
        }
    }
}
