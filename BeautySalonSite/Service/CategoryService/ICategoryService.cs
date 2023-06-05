using BeautySalonSite.Models.CategoryModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<Category>>> GetSalonCategories(int salonId);
        Task<Result<IEnumerable<Category>>> GetMasterCategories(int masterId);
    }
}
