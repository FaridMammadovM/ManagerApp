namespace ITS.PMT.Domain.Dto.ProjectDetailsDtos
{
    public sealed class InsertAddtionallInfoDto
    {
        public int ProjectId { get; set; }
        public int StageId { get; set; }
        public int StatusId { get; set; }
        public int Delay { get; set; }
        public DateTime LastDeadline { get; set; }
        public string? Note { get; set; }

    }
}
