using BeautySalonSite.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeautySalonSite.Models.EmployeeModels
{
    [AtLeastOneProperty(ErrorMessage = "Необходимо указать хотя бы одно значение")]
    public class EmployeeChange
    {
        [StringLength(40, ErrorMessage = "Максимальная длина имени 40 символов")]
        public string? Name { get; set; }

        [StringLength(40, ErrorMessage = "Максимальная длина фамилии 40 символов")]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Адрес электронной почты недействителен")]
        public string? Email { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EmployeeRole? Role { get; set; }

        [NullableProperty(nameof(IsSalonIdNullable))]
        public int? SalonId { get; set; }

        [NullableProperty(nameof(IsSpecializationNullable))]
        public string? Specialization { get; set; }

        public bool IsSalonIdNullable { get; set; } = false;

        public bool IsSpecializationNullable { get; set; } = false;
    }
}
