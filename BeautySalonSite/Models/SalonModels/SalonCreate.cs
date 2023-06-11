using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.SalonModels
{
    public class SalonCreate
    {
        [Required(ErrorMessage = "Укажите адрес филиала салона")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите город филиала салона")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Укажите номер телефона филиала салона")]
        [Phone(ErrorMessage = "Номер телефона недействителен")]
        [RegularExpression(@"\+[0-9]{12}", ErrorMessage = "Номер телефона недействителен")]
        public string Phone { get; set; } = string.Empty;
    }
}
