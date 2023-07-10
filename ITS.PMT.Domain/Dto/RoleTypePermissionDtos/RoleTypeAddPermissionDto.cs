namespace ITS.PMT.Domain.Dto.RoleTypePermissionDtos
{
    public sealed class RoleTypeAddPermissionDto
    {
        public int GroupId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}
