namespace ITS.PMT.Domain.Dto.RoleType
{
    public sealed class RoleTypePermissionAllReturnFalseDto
    {
        public List<RoleTypePermissionAllReturnFalseDataDto> RoleFalse { get; set; }
    }

    public sealed class RoleTypePermissionAllReturnFalseDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
