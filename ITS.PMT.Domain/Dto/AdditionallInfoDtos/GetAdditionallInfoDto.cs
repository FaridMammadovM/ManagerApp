namespace ITS.PMT.Domain.Dto.ProjectDetailsDtos
{
    public sealed class GetAdditionallInfoDto
    {
        public int ProjectId { get; set; }
        public int StageId { get; set; }

        public int StatusId { get; set; }

        public int PriorityId { get; set; }

        public int CategoryId { get; set; }

        public string GeneralStatus { get; set; }

        public string CurrentStatus { get; set; }
    }
}
