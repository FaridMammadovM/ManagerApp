using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.MeetingParticipant;
using ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.InsertParticipant
{
    public class InsertParticipantCommandHandler : IRequestHandler<InsertParticipantCommand, int>
    {
        private IMapper _mapper;
        private IValidator<InsertParticipantCommand> _validator;
        private IMeetingParticipantRepository _meetingParticipantRepository;

        public InsertParticipantCommandHandler(IMapper mapper, IValidator<InsertParticipantCommand> validator, IMeetingParticipantRepository meetingParticipantRepository)
        {
            _mapper = mapper;
            _validator = validator;
            _meetingParticipantRepository = meetingParticipantRepository;
        }

        public async Task<int> Handle(InsertParticipantCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var id = await _meetingParticipantRepository.InsertParticipant(_mapper.Map<MeetingParticipantModel>(request));
            return id;
        }
    }
}
