using BeautySalonSite.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.AppointmentModels
{
    public class CustomerAppointmentCreate
    {
        [Required(ErrorMessage = "Требуется указать мастера")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Требуется указать услугу")]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Требуется указать дату и время")]
        [NotPast(ErrorMessage = "Дата и время не должны быть в прошлом")]
        public DateTime Date { get; set; }
    }
}
