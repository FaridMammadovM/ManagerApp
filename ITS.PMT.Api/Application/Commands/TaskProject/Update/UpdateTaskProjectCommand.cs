using MediatR;
using System;


namespace ITS.PMT.Api.Application.Commands.TaskProject.Update
{
    public class UpdateTaskProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public DateTime Deadline { get; set; }

        public int DateNo { get; set; }

        public string? Reason { get; set; }

        public int? Delay { get; set; }

        public DateTime? LastDeadline { get; set; }

        public string? DelayReason { get; set; }

        public int ProjectId { get; set; }
    }
}
