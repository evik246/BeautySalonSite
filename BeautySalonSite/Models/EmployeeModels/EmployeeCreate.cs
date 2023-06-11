using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.EmployeeModels
{
    public class EmployeeCreate
    {
        [StringLength(40, ErrorMessage = "Максимальная длина имени 40 символов")]
        [Required(ErrorMessage = "Укажите имя")]
        public string Name { get; set; } = string.Empty;

        [StringLength(40, ErrorMessage = "Максимальная длина фамилии 40 символов")]
        [Required(ErrorMessage = "Укажите фамилию")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Адрес электронной почты недействителен")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен быть больше или равен 8 символам")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите должность")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EmployeeRole Role { get; set; }

        public int? SalonId { get; set; }

        public string? Specialization { get; set; }
    }
}
