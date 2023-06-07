using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ServiceModels;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient _httpClient;

        public ServiceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<ServiceWithoutCategory>>> GetManagerServicesByCategory(int categoryId, Paging paging)
        {
            var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceWithoutCategory>>($"service/manager/account/category/{categoryId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (services == null)
            {
                return new Result<IEnumerable<ServiceWithoutCategory>>(new ServerException());
            }

            return new Result<IEnumerable<ServiceWithoutCategory>>(services);
        }

        public async Task<Result<IEnumerable<ServiceWithoutCategory>>> GetMasterServicesByCategory(int masterId, int categoryId, Paging paging)
        {
            var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceWithoutCategory>>($"Service/master/{masterId}/category/{categoryId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (services == null)
            {
                return new Result<IEnumerable<ServiceWithoutCategory>>(new ServerException());
            }

            return new Result<IEnumerable<ServiceWithoutCategory>>(services);
        }

        public async Task<Result<IEnumerable<ServiceWithoutCategory>>> GetSalonServicesByCategory(int salonId, int categoryId, Paging paging)
        {
            var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceWithoutCategory>>($"Service/salon/{salonId}/category/{categoryId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (services == null)
            {
                return new Result<IEnumerable<ServiceWithoutCategory>>(new ServerException());
            }

            return new Result<IEnumerable<ServiceWithoutCategory>>(services);
        }

        public async Task<Result<ServiceWIthPrice>> GetServiceById(int serviceId)
        {
            var service = await _httpClient.GetFromJsonAsync<ServiceWIthPrice>($"service/{serviceId}");

            if (service == null)
            {
                return new Result<ServiceWIthPrice>(new NotFoundException());
            }
            return new Result<ServiceWIthPrice>(service);
        }

        public async Task<Result<IEnumerable<ServiceAppointmentCount>>> GetTopManagerSalonServices(int top)
        {
            if (top > Paging.MAX_PAGE_SIZE)
            {
                return new Result<IEnumerable<ServiceAppointmentCount>>(new ArgumentOutOfRangeException());
            }

            var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceAppointmentCount>>($"service/top/{top}/manager/account");

            if (services == null)
            {
                return new Result<IEnumerable<ServiceAppointmentCount>>(new ServerException());
            }

            return new Result<IEnumerable<ServiceAppointmentCount>>(services);
        }
    }
}
