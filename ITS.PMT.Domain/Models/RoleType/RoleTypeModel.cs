using DapperExtension;

namespace ITS.PMT.Domain.Models.RoleType
{
    [Table(TableName = "role_type", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class RoleTypeModel : BaseEntity
    {

        [Column(Name = "role_name")]
        public string Name { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; }
    }
}
