using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Result<IEnumerable<Master>>> GetMasters(int salonId, Paging paging);
        Task<Result<IEnumerable<Master>>> GetMastersByService(int salonId, int serviceId, Paging paging);
        Task<Result<Master>> GetMasterById(int masterId);
        Task<Result<MasterWithPhotoAndSalon>> GetMasterAccount();
    }
}
