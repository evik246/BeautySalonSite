using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.ScheduleModels
{
    public class DateRange
    {
        [Required(ErrorMessage = "Укажите начальную дату")]
        public DateOnly StartDate { get; set; }

        [Required(ErrorMessage = "Укажите конечную дату")]
        public DateOnly EndDate { get; set; }
    }
}
