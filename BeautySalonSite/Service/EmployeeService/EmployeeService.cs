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

        public async Task<Result<MasterWithEmail>> GetManagerMasterById(int masterId)
        {
            var master = await _httpClient.GetFromJsonAsync<MasterWithEmail>($"employee/manager/account/master/{masterId}");

            if ( master == null )
            {
                return new Result<MasterWithEmail>(new NotFoundException());
            }
            return new Result<MasterWithEmail>(master);
        }

        public async Task<Result<IEnumerable<MasterWithEmail>>> GetManagerMasters(Paging paging)
        {
            var masters = await _httpClient.GetFromJsonAsync<IEnumerable<MasterWithEmail>>($"employee/manager/account/master?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (masters == null)
            {
                return new Result<IEnumerable<MasterWithEmail>>(new ServerException());
            }
            return new Result<IEnumerable<MasterWithEmail>>(masters);
        }

        public async Task<Result<IEnumerable<MasterWithEmail>>> GetManagerMastersByService(int serviceId, Paging paging)
        {
            var masters = await _httpClient.GetFromJsonAsync<IEnumerable<MasterWithEmail>>($"employee/manager/account/master/service/{serviceId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (masters == null)
            {
                return new Result<IEnumerable<MasterWithEmail>>(new ServerException());
            }
            return new Result<IEnumerable<MasterWithEmail>>(masters);
        }

        public async Task<Result<IEnumerable<MasterWithEmail>>> GetManagerMastersByServiceCategory(int categoryId, Paging paging)
        {
            var masters = await _httpClient.GetFromJsonAsync<IEnumerable<MasterWithEmail>>($"employee/manager/account/master/category/{categoryId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (masters == null)
            {
                return new Result<IEnumerable<MasterWithEmail>>(new ServerException());
            }
            return new Result<IEnumerable<MasterWithEmail>>(masters);
        }

        public async Task<Result<MasterWithPhotoAndSalon>> GetMasterAccount()
        {
            var master = await _httpClient.GetFromJsonAsync<MasterWithPhotoAndSalon>("employee/master/account");

            if (master == null)
            {
                return new Result<MasterWithPhotoAndSalon>(new ServerException());
            }
            return new Result<MasterWithPhotoAndSalon>(master);
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

        public async Task<Result<IEnumerable<Master>>> GetMastersByService(int salonId, int serviceId, Paging paging)
        {
            var masters = await _httpClient.GetFromJsonAsync<IEnumerable<Master>>($"employee/salon/{salonId}/master/service/{serviceId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (masters == null)
            {
                return new Result<IEnumerable<Master>>(new ServerException());
            }

            return new Result<IEnumerable<Master>>(masters);
        }
    }
}
