using Newtonsoft.Json;



namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class GetAllProjectCountByCategoryWithMonthDto
    {
        [JsonProperty("CountMonth")]
        public int count_month { get; set; }

        [JsonProperty("MonthName")]
        public string month_name { get; set; }


    }
}
