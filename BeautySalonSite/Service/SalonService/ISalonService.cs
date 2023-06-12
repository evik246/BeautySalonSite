using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.SalonModels;
using BeautySalonSite.Models.ScheduleModels;

namespace BeautySalonSite.Service.SalonService
{
    public interface ISalonService
    {
        Task<Result<int>> GetSalonIdFromLocalStorage();
        Task<Result<IEnumerable<SalonWithAddressAndCity>>> GetSalonsWithAddress();
        Task<Result<SalonWithAddressAndCity>> GetSalonWithAddressById(int salonId);
        Task SetSalonIdInLocalStorage(int salonId);
        Task RemoveSalonIdFromLocalStorage();
        Task<Result<SalonFull>> GetManagerSalon();
        Task<Result<string>> CreateSalon(SalonCreate request);
        Task<Result<string>> UpdateSalon(int salonId, SalonChange request);
        Task<Result<string>> DeleteSalon(int salonId);
        Task<Result<IEnumerable<SalonFull>>> GetSalonsByCity(int cityId);
        Task<Result<decimal>> GetManagerSalonIncome(DateRange dateRange);
        Task<Result<decimal>> GetSalonIncome(int salonId, DateRange dateRange);
    }
}
