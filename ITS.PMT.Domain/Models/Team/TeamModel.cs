using DapperExtension;

namespace ITS.PMT.Domain.Models.Team
{
    [Table(TableName = "team", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class TeamModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "project_id")]
        public int ProjectId { get; set; }
        //public ProjectModel ProjectModel { get; set; }
        [Column(Name = "role_id")]
        public int RoleId { get; set; }
        //public RoleModel RoleModel { get; set; }
        [Column(Name = "employee_id")]
        public int EmployeeId { get; set; }
        //public EmployeeModel EmployeeModel { get; set; }
        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }

        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; }
    }
}
