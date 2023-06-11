using BeautySalonSite.Models.ErrorModels;
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

        public async Task<Result<string>> CreateService(ServiceCreate request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("service", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var error = await response.Content.ReadFromJsonAsync<Error>();

                if (error != null && error.Message.Contains("category")) 
                {
                    return new Result<string>(new NotFoundException());
                }
            }

            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> UpdateService(int serviceId, ServiceChange request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"service/{serviceId}", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                var error = await response.Content.ReadFromJsonAsync<Error>();

                if (error != null && error.Message.Contains("category"))
                {
                    return new Result<string>(new NotFoundException("Category is not found"));
                }

                if (error != null && !error.Message.Contains("category"))
                {
                    return new Result<string>(new NotFoundException("Service is not found"));
                }
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ErrorResponse>();

                if (errorResponse?.Errors != null && errorResponse.Errors.ContainsKey(""))
                {
                    var errorMessage = errorResponse.Errors[""][0];
                    if (errorMessage.Equals("At least one property must be specified"))
                    {
                        return new Result<string>(new NoInputContentException());
                    }
                }
            }

            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> DeleteService(int serviceId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"service/{serviceId}");

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new Result<string>(new NotFoundException());
            }

            return new Result<string>(new ServerException());
        }

        public async Task<Result<IEnumerable<ServiceWithoutCategory>>> GetAllServicesByCategory(int categoryId, Paging paging)
        {
            var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceWithoutCategory>>($"service/category/{categoryId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (services == null)
            {
                return new Result<IEnumerable<ServiceWithoutCategory>>(new ServerException());
            }

            return new Result<IEnumerable<ServiceWithoutCategory>>(services);
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
