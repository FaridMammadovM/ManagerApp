namespace ITS.PMT.Domain.Dto.ProtocolDtos
{
    public sealed class GetProtocolsByIdDto
    {
        public string RoleName { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
