namespace ITS.PMT.Domain.Dto.TeamDtos
{
    public sealed class GetTeamByProjectIdDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
