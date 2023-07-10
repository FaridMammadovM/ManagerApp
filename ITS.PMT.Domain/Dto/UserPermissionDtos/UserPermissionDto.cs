namespace ITS.PMT.Domain.Dto.UserPermissionDtos
{
    public sealed class UserPermissionDto
    {
        public int UserId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}
