using BeautySalonSite.Models.CategoryModels;

namespace BeautySalonSite.Models.ServiceModels
{
    public class ServiceAppointmentCount
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public Category Category { get; set; } = new();

        public long AppointmentsCount { get; set; }
    }
}
