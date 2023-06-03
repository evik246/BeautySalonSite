using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.CustomerModels
{
    public class ResetPasswordRequest
    {
        [Required(ErrorMessage = "Требуется текущий пароль")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Требуется новый пароль")]
        [MinLength(8, ErrorMessage = "Пароль должен быть больше или равен 8 символам")]
        public string NewPassword { get; set; } = string.Empty;

        [Compare("NewPassword", ErrorMessage = "Пароль и пароль подтверждения не совпадают")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
