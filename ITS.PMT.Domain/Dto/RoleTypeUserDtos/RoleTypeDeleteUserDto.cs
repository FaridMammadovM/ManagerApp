namespace ITS.PMT.Domain.Dto.RoleTypeUserDtos
{
    public sealed class RoleTypeDeleteUserDto
    {
        public int GroupId { get; set; }
        public List<int> UserId { get; set; }
    }
}
