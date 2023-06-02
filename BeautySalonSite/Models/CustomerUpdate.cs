using BeautySalonSite.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models
{
    [AtLeastOneProperty(ErrorMessage = "Необходимо указать хотя бы одно значение")]
    public class CustomerUpdate
    {
        [StringLength(40, ErrorMessage = "Максимальная длина имени 40 символов")]
        public string? Name { get; set; }

        [NullableProperty(nameof(IsBirthdayNullable))]
        [Birthday(MinAge = 1, MaxAge = 100, ErrorMessage = "Дата рождения недействительна")]
        public DateOnly? Birthday { get; set; }

        [EmailAddress(ErrorMessage = "Адрес электронной почты недействителен")]
        public string? Email { get; set; }

        [RegularExpression(@"\+[0-9]{12}", ErrorMessage = "Номер телефона недействителен")]
        public string? Phone { get; set; }

        public bool IsBirthdayNullable { get; set; } = false;
    }
}
