namespace ITS.PMT.Domain.Dto.RoleTypePermissionDtos
{
    public sealed class RoleTypeDeletePermissionDto
    {
        public int GroupId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}
