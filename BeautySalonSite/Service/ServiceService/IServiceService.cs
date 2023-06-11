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
        Task<Result<IEnumerable<ServiceAppointmentCount>>> GetTopManagerSalonServices(int top);
        Task<Result<IEnumerable<ServiceWithoutCategory>>> GetAllServicesByCategory(int categoryId, Paging paging);
        Task<Result<string>> CreateService(ServiceCreate request);
        Task<Result<string>> UpdateService(int serviceId, ServiceChange request);
        Task<Result<string>> DeleteService(int serviceId);
    }
}
