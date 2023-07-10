
using DapperExtension;

namespace ITS.PMT.Domain.Models.Employee
{
    [Table(TableName = "employee", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class EmployeeModel
    {


        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "first_name")]
        public string FirstName { get; set; } = null!;

        [Column(Name = "last_name")]
        public string LastName { get; set; } = null!;

        [Column(Name = "role_id")]
        public int RoleId { get; set; }
        [Column(Name = "mail")]
        public string Mail { get; set; }
        // public RoleModel RoleModel { get; set; }

        //public List<TeamModel>? TeamModel { get; set; }

    }
}