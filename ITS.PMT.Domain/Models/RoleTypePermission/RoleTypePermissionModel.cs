using DapperExtension;

namespace ITS.PMT.Domain.Models.RoleTypePermission
{
    [Table(TableName = "role_type_permission", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class RoleTypePermissionModel : BaseEntity
    {
        [Column(Name = "permission_id")]
        public int PermissionId { get; set; }

        [Column(Name = "role_type_id")]
        public int RoleId { get; set; }
    }
}
