using BeautySalonSite.Models.EmployeeModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<Master>>> GetMasters(int salonId, Paging paging)
        {
            var masters = await _httpClient.GetFromJsonAsync<IEnumerable<Master>>($"employee/salon/{salonId}/master?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (masters == null)
            {
                return new Result<IEnumerable<Master>>(new ServerException());
            }
            return new Result<IEnumerable<Master>>(masters);
        }
    }
}
