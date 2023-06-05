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

        public async Task<Result<Master>> GetMasterById(int masterId)
        {
            var master = await _httpClient.GetFromJsonAsync<Master>($"employee/master/{masterId}");
            if (master == null )
            {
                return new Result<Master>(new NotFoundException());
            }
            return new Result<Master>(master);
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
