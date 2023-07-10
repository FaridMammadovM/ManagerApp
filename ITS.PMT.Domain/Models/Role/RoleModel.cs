using DapperExtension;


namespace ITS.PMT.Domain.Models.Role
{
    [Table(TableName = "role", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class RoleModel
    {

        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "role_desc")]

        public string Description { get; set; } = null!;

    }
}
