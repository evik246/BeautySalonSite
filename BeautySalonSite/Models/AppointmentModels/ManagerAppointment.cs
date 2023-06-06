using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.ServiceModels;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.AppointmentModels
{
    public class ManagerAppointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public CustomerWithName Customer { get; set; } = new();

        public MasterWithName Master { get; set; } = new();

        public ServiceWithName Service { get; set; } = new();

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AppointmentStatus Status { get; set; }

        public decimal? Price { get; set; }
    }

    public enum AppointmentStatus
    {
        [Description("Предстоящая")]
        Active = 0,
        [Description("Завершенная")]
        Completed = 1
    }
}
