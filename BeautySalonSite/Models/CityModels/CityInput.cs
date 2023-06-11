using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.CityModels
{
    public class CityInput
    {
        [Required(ErrorMessage = "Укажите название города")]
        public string Name { get; set; } = string.Empty;
    }
}
