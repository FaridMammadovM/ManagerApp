namespace ITS.PMT.Domain.Dto.DeadlineOutInfoDtos
{
    public sealed class CreateDeadlineOutInfoDto
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
