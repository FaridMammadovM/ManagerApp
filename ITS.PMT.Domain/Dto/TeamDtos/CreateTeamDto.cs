namespace ITS.PMT.Domain.Dto.TeamDtos
{
    public sealed class CreateTeamDto
    {
        public int RoleId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
