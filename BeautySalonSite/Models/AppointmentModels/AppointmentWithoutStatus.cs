using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.ServiceModels;

namespace BeautySalonSite.Models.AppointmentModels
{
    public class AppointmentWithoutStatus
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public CustomerWithName Customer { get; set; } = new();

        public MasterWithName Master { get; set; } = new();

        public ServiceWithName Service { get; set; } = new();

        public decimal? Price { get; set; }
    }
}
