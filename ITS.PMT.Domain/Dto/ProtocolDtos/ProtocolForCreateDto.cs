namespace ITS.PMT.Domain.Dto.ProtocolDtos
{
    public sealed class ProtocolForCreateDto
    {
        public int MeetingId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public string? Description { get; set; }
        public string? InsertUser { get; set; }

    }
}
