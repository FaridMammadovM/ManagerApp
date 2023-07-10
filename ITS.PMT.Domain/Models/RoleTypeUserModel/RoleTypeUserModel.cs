using DapperExtension;


namespace ITS.PMT.Domain.Models.RoleTypeUserModel
{
    [Table(TableName = "employee_role_type", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class RoleTypeUserModel : BaseEntity
    {
        [Column(Name = "employee_id")]
        public int Employee_id { get; set; }

        [Column(Name = "role_id")]
        public int RoleId { get; set; }
    }
}
