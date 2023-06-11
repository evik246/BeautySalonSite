using BeautySalonSite.Models.CategoryModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<Category>>> GetSalonCategories(int salonId);
        Task<Result<IEnumerable<Category>>> GetMasterCategories(int masterId);
        Task<Result<IEnumerable<Category>>> GetManagerCategories();
        Task<Result<IEnumerable<Category>>> GetAllCategories();
        Task<Result<string>> CreateCategory(CategoryInput request);
        Task<Result<string>> ChangeCategory(int categoryId, CategoryInput request);
        Task<Result<string>> DeleteCategory(int categoryId);
    }
}
