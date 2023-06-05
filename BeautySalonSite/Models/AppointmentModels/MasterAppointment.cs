using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.ServiceModels;

namespace BeautySalonSite.Models.AppointmentModels
{
    public class MasterAppointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public ServiceWithName Service { get; set; } = new();

        public CustomerWithName Customer { get; set; } = new();
    }
}
