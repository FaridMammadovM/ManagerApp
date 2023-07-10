namespace ITS.PMT.Domain.Dto.RoleTypeUserDtos
{
    public sealed class RoleTypeUserGetAllDto
    {
        public RoleTypeUserAllReturnFalseDto RoleFalse { get; set; }
        public RoleTypeUserAllReturnTrueDto RoleTrue { get; set; }
    }

    public sealed class RoleTypeUserAllReturnFalseDto
    {
        public List<RoleTypeUserAllReturnFalseDataDto> RoleFalse { get; set; }
    }

    public sealed class RoleTypeUserAllReturnFalseDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public sealed class RoleTypeUserAllReturnTrueDto
    {
        public List<RoleTypeUserAllReturnTrueDataDto> RoleTrue { get; set; }
    }

    public sealed class RoleTypeUserAllReturnTrueDataDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
