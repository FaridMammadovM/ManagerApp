using DapperExtension;

namespace ITS.PMT.Domain.Models.ProjectDetails
{
    [Table(TableName = "proj_details", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class ProjectDetailsModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "proj_id")]
        public int ProjectId { get; set; }

        [Column(Name = "stage_id")]
        public int StageId { get; set; }

        [Column(Name = "status_id")]
        public int StatusId { get; set; }


        [Column(Name = "priority_id")]
        public int PriorityId { get; set; }

        [Column(Name = "category_id")]
        public int CategoryId { get; set; }

        [Column(Name = "general_status")]
        public string GeneralStatus { get; set; }

        [Column(Name = "current_status")]
        public string CurrentStatus { get; set; }

        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; }

        [Column(Name = "update_date")]
        public DateTime UpdateDate { get; set; }
    }
}
