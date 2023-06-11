using System.ComponentModel.DataAnnotations;

namespace BeautySalonSite.Models.CategoryModels
{
    public class CategoryInput
    {
        [Required(ErrorMessage = "Укажите название категории услуг")]
        public string Name { get; set; } = string.Empty;
    }
}
