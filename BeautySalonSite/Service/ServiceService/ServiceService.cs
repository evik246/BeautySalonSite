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

        public async Task<Result<IEnumerable<ServiceWithoutCategory>>> GetServicesByCategory(int salonId, int categoryId, Paging paging)
        {
            var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceWithoutCategory>>($"Service/salon/{salonId}/category/{categoryId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (services == null)
            {
                return new Result<IEnumerable<ServiceWithoutCategory>>(new ServerException());
            }

            return new Result<IEnumerable<ServiceWithoutCategory>>(services);
        }
    }
}
