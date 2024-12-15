using System.Text.Json.Serialization;

namespace Clickhouse.Kata.API.Models
{
    public class GitCommitWeekDay
    {
        [JsonIgnore]
        public int DayOfWeekNum { get; set; }
        public int NumberOfCommits { get; set; }

        public DayOfWeek DayOfWeek => (DayOfWeek)DayOfWeekNum;
    }
}
