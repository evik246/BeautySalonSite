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

        public async Task<Result<string>> ChangeEmployee(int employeeId, EmployeeChange request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"employee/{employeeId}", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                return new Result<string>(new UsedEmailException());
            }
            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> CreateEmployee(EmployeeCreate request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("employee", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                return new Result<string>(new UsedEmailException());
            }
            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> DeleteEmployee(int employeeId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"employee/{employeeId}");

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

        public async Task<Result<IEnumerable<Employee>>> GetAllEmployees(Paging paging, EmployeeFiltration filtration)
        {
            string query = $"employee?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}";

            if (filtration.SalonId != null)
            {
                query += $"&SalonId={filtration.SalonId}";
            }

            if (filtration.Role != null)
            {
                query += $"&Role={filtration.Role}";
            }

            var employees = await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>(query);

            if (employees == null)
            {
                return new Result<IEnumerable<Employee>>(new ServerException());
            }
            return new Result<IEnumerable<Employee>>(employees);
        }

        public async Task<Result<Employee>> GetEmployeeById(int employeeId)
        {
            var employee = await _httpClient.GetFromJsonAsync<Employee>($"employee/{employeeId}");

            if (employee == null)
            {
                return new Result<Employee>(new NotFoundException());
            }
            return new Result<Employee>(employee);
        }

        public async Task<Result<IEnumerable<MasterWithEmail>>> GetAvailableMastersToChange(int appointmentId)
        {
            try
            {
                var masters = await _httpClient.GetFromJsonAsync<IEnumerable<MasterWithEmail>>($"employee/appointment/{appointmentId}/available/manager/account");

                if (masters == null)
                {
                    return new Result<IEnumerable<MasterWithEmail>>(new ServerException());
                }
                return new Result<IEnumerable<MasterWithEmail>>(masters);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<MasterWithEmail>>(new ServerException(ex.Message));
            }
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

        public async Task<Result<IEnumerable<MasterAppointmentCount>>> GetTopManagerSalonMasters(int top)
        {
            if (top > Paging.MAX_PAGE_SIZE)
            {
                return new Result<IEnumerable<MasterAppointmentCount>>(new ArgumentOutOfRangeException());
            }

            var masters = await _httpClient.GetFromJsonAsync<IEnumerable<MasterAppointmentCount>>($"Employee/top/{top}/manager/account");

            if (masters == null)
            {
                return new Result<IEnumerable<MasterAppointmentCount>>(new ServerException());
            }
            return new Result<IEnumerable<MasterAppointmentCount>>(masters);
        }
    }
}
