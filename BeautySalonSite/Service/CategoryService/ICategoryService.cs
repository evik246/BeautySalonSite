using BeautySalonSite.Models.CategoryModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<Category>>> GetCategories(int salonId);
    }
}
