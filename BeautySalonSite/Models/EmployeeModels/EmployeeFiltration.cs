using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.EmployeeModels
{
    public class EmployeeFiltration
    {
        public int? SalonId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EmployeeRole? Role { get; set; }
    }
}
