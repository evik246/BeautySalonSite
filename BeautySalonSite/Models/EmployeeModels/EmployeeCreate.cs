using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.EmployeeModels
{
    public class EmployeeCreate
    {
        [StringLength(40, ErrorMessage = "Max length of the name is 40")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [StringLength(40, ErrorMessage = "Max length of the name is 40")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password should be greater than or equal 8 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role is required")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EmployeeRole Role { get; set; }

        public int? SalonId { get; set; }

        public string? Specialization { get; set; }
    }
}
