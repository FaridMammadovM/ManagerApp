namespace ITS.PMT.Domain.Dto.Employee
{
    public sealed class GetAllPermissionByUserDto
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public bool po { get; set; }
        public Dictionary<string, bool> data { get; set; }
    }

    public sealed class GetAllPermissionByUserDataDto
    {
        public string Permission_Code { get; set; }
    }
}
