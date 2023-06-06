using BeautySalonSite.Attributes;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.ScheduleModels
{
    [AtLeastOneProperty(ErrorMessage = "At least one property must be specified")]
    public class MasterScheduleChange
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Weekday? Weekday { get; set; }

        public TimeOnly? StartTime { get; set; } = null;

        public TimeOnly? EndTime { get; set; } = null;
    }
}
