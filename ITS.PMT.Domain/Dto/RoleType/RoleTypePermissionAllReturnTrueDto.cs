namespace ITS.PMT.Domain.Dto.RoleType
{
    public sealed class RoleTypePermissionAllReturnTrueDto
    {
        public List<RoleTypePermissionAllReturnTrueDataDto> RoleTrue { get; set; }
    }

    public sealed class RoleTypePermissionAllReturnTrueDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
