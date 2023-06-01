using BeautySalonSite.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models
{
    public class ClientRegistration
    {
        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(40, ErrorMessage = "Максимальная длина имени 40 символов")]
        public string Name { get; set; } = string.Empty;

        [Birthday(MinAge = 1, MaxAge = 100, ErrorMessage = "Дата рождения недействительна")]
        public DateOnly? Birthday { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Адрес электронной почты недействителен")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен быть больше или равен 8 символам")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите номер телефона")]
        [Phone(ErrorMessage = "Номер телефона недействителен")]
        [RegularExpression(@"\+[0-9]{12}", ErrorMessage = "Номер телефона недействителен")]
        public string Phone { get; set; } = string.Empty;
    }
}
