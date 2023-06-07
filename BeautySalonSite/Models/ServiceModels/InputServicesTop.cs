using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.ServiceModels
{
    public class InputServicesTop
    {
        [Range(1, 25, ErrorMessage = "Укажите число записей в рейтинге от 1 до 25")]
        public int Top { get; set; }
    }
}
