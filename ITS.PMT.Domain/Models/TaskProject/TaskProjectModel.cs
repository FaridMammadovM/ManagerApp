using DapperExtension;


namespace ITS.PMT.Domain.Models.TaskProject
{
    [Table(TableName = "project_task", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class TaskProjectModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "task_name")]
        public string TaskName { get; set; }

        [Column(Name = "deadline")]
        public DateTime Deadline { get; set; }

        [Column(Name = "dateno")]
        public int DateNo { get; set; }

        [Column(Name = "reason")]
        public string Reason { get; set; }

        [Column(Name = "delay")]
        public int Delay { get; set; }

        [Column(Name = "lastdeadline")]
        public DateTime? LastDeadline { get; set; }

        [Column(Name = "delayreason")]
        public string DelayReason { get; set; }

        [Column(Name = "project_id")]
        public int ProjectId { get; set; }

        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; }

        [Column(Name = "update_date")]
        public DateTime UpdateDate { get; set; }

        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }

        [Column(Name = "Status")]
        public int Status { get; set; }
    }
}
