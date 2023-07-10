using DapperExtension;

namespace ITS.PMT.Domain.Models.Task
{
    [Table(TableName = "task", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class TaskModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "task_name")]
        public string TaskName { get; set; } = null!;

        [Column(Name = "task_no")]
        public string TaskNo { get; set; } = null!;

        [Column(Name = "description")]
        public string Description { get; set; } = null!;

        [Column(Name = "begin_date")]
        public DateTime BeginDate { get; set; }

        [Column(Name = "end_date")]
        public DateTime EndDate { get; set; }

        [Column(Name = "deadline")]
        public DateTime Deadline { get; set; }

        [Column(Name = "project_id")]
        public int ProjectId { get; set; }
        //public ProjectModel? ProjectModel { get; set; }

        [Column(Name = "status_id")]
        public int StatusId { get; set; }
        // public StatusModel? StatusModel { get; set; }

        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }

        [Column(Name = "stage_id")]
        public int StageId { get; set; }
        //public StageModel? StageModel { get; set; }

        [Column(Name = "team_id")]
        public int TeamId { get; set; }
        //public TeamModel? TeamModel { get; set; }

        [Column(Name = "exec_time")]
        public int ExecTime { get; set; }

        [Column(Name = "perf_indicator")]
        public int PerfIndicator { get; set; }



    }
}