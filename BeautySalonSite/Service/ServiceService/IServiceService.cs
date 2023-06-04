using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ServiceModels;

namespace BeautySalonSite.Service.ServiceService
{
    public interface IServiceService
    {
        Task<Result<IEnumerable<ServiceWithoutCategory>>> GetServicesByCategory(int salonId, int categoryId, Paging paging);
    }
}
