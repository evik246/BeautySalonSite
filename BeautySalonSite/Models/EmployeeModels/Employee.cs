using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.EmployeeModels
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EmployeeRole Role { get; set; }

        public int? SalonId { get; set; }

        public string? PhotoPath { get; set; }

        public string? PhotoURL { get; set; }

        public string? Specialization { get; set; }

        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }

    public enum EmployeeRole
    {
        [Description("Мастер")]
        Master = 0,
        [Description("Менеджер")]
        Manager = 1,
        [Description("Администратор")]
        Admin = 2
    }
}
