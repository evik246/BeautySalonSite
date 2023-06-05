using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.ScheduleModels
{
    public class MasterSchedule
    {
        public int Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Weekday Weekday { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }

    public enum Weekday
    {
        [Description("Понедельник")]
        Monday = 0,
        [Description("Вторник")]
        Tuesday = 1,
        [Description("Среда")]
        Wednesday = 2,
        [Description("Четверг")]
        Thursday = 3,
        [Description("Пятница")]
        Friday = 4,
        [Description("Суббота")]
        Saturday = 5,
        [Description("Воскресенье")]
        Sunday = 6
    }
}
