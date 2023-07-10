namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class GetAllProjectNumberDto
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Projectmanager { get; set; }
        public string Projectowner { get; set; }
        public int?[]? PoId { get; set; }
        public string Prior_desc { get; set; }
        public string Category { get; set; }
        public string Stage_desc { get; set; }
        public string General_status { get; set; }
        public string Current_status { get; set; }
        public List<GetAllProjectTaskNumberDto> GetAllProject { get; set; }
    }

    public sealed class GetAllProjectTaskNumberDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }

        public string Deadline { get; set; }

        public string? Reason { get; set; }

        public string? Delay { get; set; }

        public string? LastDeadline { get; set; }

        public string? DelayReason { get; set; }

    }

    public sealed class GetAllPoIdWithProjectDto
    {
        public int Id { get; set; }
        public int? Poid { get; set; }
    }
}
