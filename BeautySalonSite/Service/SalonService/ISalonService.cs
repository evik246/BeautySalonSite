using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.SalonModels;

namespace BeautySalonSite.Service.SalonService
{
    public interface ISalonService
    {
        Task<Result<int>> GetSalonIdFromLocalStorage();
        Task<Result<IEnumerable<SalonWithOnlyAddress>>> GetSalonsWithAddress();
        Task SetSalonIdInLocalStorage(int salonId);
        Task RemoveSalonIdFromLocalStorage();
    }
}
