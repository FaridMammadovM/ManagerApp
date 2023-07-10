namespace ITS.PMT.Domain.Dto.UserPermissionDtos
{
    public sealed class UserDeletePermissionDto
    {
        public int UserId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}
