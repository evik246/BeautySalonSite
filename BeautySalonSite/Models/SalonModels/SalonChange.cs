using BeautySalonSite.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.SalonModels
{
    [AtLeastOneProperty(ErrorMessage = "At least one property must be specified")]
    public class SalonChange
    {
        public string? Address { get; set; }

        public int? CityId { get; set; }

        [Phone(ErrorMessage = "Номер телефона недействителен")]
        [RegularExpression(@"\+[0-9]{12}", ErrorMessage = "Номер телефона недействителен")]
        public string? Phone { get; set; }
    }
}
