using DapperExtension;


namespace ITS.PMT.Domain.Models.UserPermission
{
    [Table(TableName = "employee_per", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class UserPermissionModel : BaseEntity
    {
        [Column(Name = "permission_id")]
        public int PermissionId { get; set; }

        [Column(Name = "employee_id")]
        public int EmployeeId { get; set; }
    }
}
