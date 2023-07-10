namespace ITS.PMT.Domain.Dto.RoleType
{
    public sealed class RoleTypePermissionAllReturnDto
    {
        public RoleTypePermissionAllReturnFalseDto RoleFalse { get; set; }
        public RoleTypePermissionAllReturnTrueDto RoleTrue { get; set; }
    }
}
