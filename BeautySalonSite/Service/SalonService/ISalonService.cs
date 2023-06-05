using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.SalonModels;

namespace BeautySalonSite.Service.SalonService
{
    public interface ISalonService
    {
        Task<Result<int>> GetSalonIdFromLocalStorage();
        Task<Result<IEnumerable<SalonWithAddressAndCity>>> GetSalonsWithAddress();
        Task<Result<SalonWithAddressAndCity>> GetSalonWithAddressById(int salonId);
        Task SetSalonIdInLocalStorage(int salonId);
        Task RemoveSalonIdFromLocalStorage();
    }
}
