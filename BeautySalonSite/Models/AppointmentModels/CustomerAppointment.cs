using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.ServiceModels;

namespace BeautySalonSite.Models.AppointmentModels
{
    public class CustomerAppointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public ServiceWIthPrice Service { get; set; } = new();

        public MasterWithName Master { get; set; } = new();
    }
}
