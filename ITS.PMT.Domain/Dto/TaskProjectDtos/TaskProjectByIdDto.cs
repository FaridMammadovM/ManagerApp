namespace ITS.PMT.Domain.Dto.TaskProjectDtos
{
    public sealed class TaskProjectByIdDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public DateTime Deadline { get; set; }

        public int DateNo { get; set; }

        public string? Reason { get; set; }

        public int? Delay { get; set; }

        public string? LastDeadline { get; set; }

        public string? DelayReason { get; set; }

        public int ProjectId { get; set; }

        public int Status { get; set; }
    }
}
