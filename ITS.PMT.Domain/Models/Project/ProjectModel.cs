using DapperExtension;

namespace ITS.PMT.Domain.Models.Project
{

    [Table(TableName = "project", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public sealed class ProjectModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "project_name")]

        public string ProjectName { get; set; } = null!;
        [Column(Name = "project_code")]
        public string ProjectCode { get; set; } = null!;
        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; } = DateTime.Now;
        [Column(Name = "update_date")]
        public DateTime? UpdateDate { get; set; }
        [Column(Name = "insert_user")]
        public string InsertUser { get; set; } = null!;
        [Column(Name = "update_user")]
        public string UpdateUser { get; set; } = null!;
        [Column(Name = "department_desc")]
        public string DepartmentDesc { get; set; } = null!;

        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }
        [Column(Name = "description")]
        public string Description { get; set; } = null!;


    }
}
