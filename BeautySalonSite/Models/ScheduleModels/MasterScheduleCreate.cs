using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.ScheduleModels
{
    public class MasterScheduleCreate
    {
        [Required(ErrorMessage = "Укажите день недели")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Weekday Weekday { get; set; }

        [Required(ErrorMessage = "Укажите время начала рабочего дня")]
        public TimeOnly StartTime { get; set; }

        [Required(ErrorMessage = "Укажите время окончания рабочего дня")]
        public TimeOnly EndTime { get; set; }
    }
}
