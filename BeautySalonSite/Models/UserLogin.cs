using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты.")]
        [EmailAddress(ErrorMessage = "Адрес электронной почты недействителен")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите пароль")]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
    }
}
