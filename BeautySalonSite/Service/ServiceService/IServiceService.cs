using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ServiceModels;

namespace BeautySalonSite.Service.ServiceService
{
    public interface IServiceService
    {
        Task<Result<IEnumerable<ServiceWithoutCategory>>> GetSalonServicesByCategory(int salonId, int categoryId, Paging paging);
        Task<Result<IEnumerable<ServiceWithoutCategory>>> GetMasterServicesByCategory(int masterId, int categoryId, Paging paging);
        Task<Result<IEnumerable<ServiceWithoutCategory>>> GetManagerServicesByCategory(int categoryId, Paging paging);
        Task<Result<ServiceWIthPrice>> GetServiceById(int serviceId);
    }
}
