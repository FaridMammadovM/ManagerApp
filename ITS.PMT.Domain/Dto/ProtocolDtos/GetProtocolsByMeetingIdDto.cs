namespace ITS.PMT.Domain.Dto.ProtocolDtos
{
    public sealed class GetProtocolsByMeetingIdDto
    {
        public int Id { get; set; }
        public string EmpFullName { get; set; } = null!;
        public int partid { get; set; }
        public string RolName { get; set; } = null!;
        public string CommentDesc { get; set; } = null!;
        public int ProjId { get; set; }
        public string ProjectName { get; set; }

    }
}
