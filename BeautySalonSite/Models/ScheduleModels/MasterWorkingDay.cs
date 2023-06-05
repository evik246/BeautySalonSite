namespace BeautySalonSite.Models.ScheduleModels
{
    public class MasterWorkingDay
    {
        public DateOnly Date { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}
