namespace ITS.PMT.Domain.Dto.Employee
{
    public sealed class EmployeePermissionGetAllDto
    {
        public UserPermissionAllReturnFalseDto RoleFalse { get; set; }
        public UserPermissionAllReturnTrueDto RoleTrue { get; set; }
    }

    public sealed class UserPermissionAllReturnFalseDto
    {
        public List<UserPermissionAllReturnFalseDataDto> RoleFalse { get; set; }
    }

    public sealed class UserPermissionAllReturnFalseDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public sealed class UserPermissionAllReturnTrueDto
    {
        public List<UserPermissionAllReturnTrueDataDto> RoleTrue { get; set; }
    }

    public sealed class UserPermissionAllReturnTrueDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
