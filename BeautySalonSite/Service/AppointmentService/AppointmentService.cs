using BeautySalonSite.Models.AppointmentModels;
using BeautySalonSite.Models.ErrorModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ScheduleModels;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HttpClient _httpClient;

        public AppointmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<CustomerAppointment>>> GetActiveCustomerAppointments(int salonId, Paging paging)
        {
            var appointments = await _httpClient.GetFromJsonAsync<IEnumerable<CustomerAppointment>>($"appointment/customer/account/salon/{salonId}?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (appointments == null)
            {
                return new Result<IEnumerable<CustomerAppointment>>(new ServerException());
            }
            return new Result<IEnumerable<CustomerAppointment>>(appointments);
        }

        public async Task<Result<CustomerAppointment>> GetCustomerAppointmentById(int appointmentId)
        {
            var appointment = await _httpClient.GetFromJsonAsync<CustomerAppointment>($"appointment/{appointmentId}/customer/account");

            if (appointment == null)
            {
                return new Result<CustomerAppointment>(new NotFoundException());
            }
            return new Result<CustomerAppointment>(appointment);
        }

        public async Task<Result<string>> CancelCustomerAppointment(int appointmentId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"appointment/{appointmentId}/customer/account");

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

        public async Task<Result<string>> MakeCustomerAppointment(CustomerAppointmentCreate request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("appointment/customer/account", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            var error = await response.Content.ReadFromJsonAsync<Error>();

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                if (error != null)
                {
                    return new Result<string>(new ConflictException(error.Message));
                }
            }

            return new Result<string>(new ServerException());
        }

        public async Task<Result<IEnumerable<MasterAppointment>>> GetMasterAppointments(Paging paging)
        {
            var appointments = await _httpClient.GetFromJsonAsync<IEnumerable<MasterAppointment>>($"appointment/master/account?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (appointments == null)
            {
                return new Result<IEnumerable<MasterAppointment>>(new ServerException());
            }
            return new Result<IEnumerable<MasterAppointment>>(appointments);
        }

        public async Task<Result<string>> MarkMasterAppointmentComplete(int appointmentId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync($"appointment/{appointmentId}/master/account/mark_complete", null);

                if (response.IsSuccessStatusCode)
                {
                    return new Result<string>("Success");
                }

                var error = await response.Content.ReadFromJsonAsync<Error>();

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new Result<string>(new NotFoundException());
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    if (error != null && error.Message.Contains("Appointment has not happened yet"))
                    {
                        return new Result<string>(new UpcomingAppointmentException());
                    }
                    return new Result<string>(new ConflictException());
                }
                return new Result<string>(new ServerException());
            }
            catch (Exception ex)
            {
                return new Result<string>(new ServerException(ex.Message));
            }
        }

        public async Task<Result<int>> GetMasterAppointmentCount(DateRange dateRange)
        {
            var count = await _httpClient.GetFromJsonAsync<int>($"appointment/master/account/count?StartDate={dateRange.StartDate:yyyy-MM-dd}&EndDate={dateRange.EndDate:yyyy-MM-dd}");

            return new Result<int>(count);
        }

        public async Task<Result<decimal>> GetMasterAppointmentIncome(DateRange dateRange)
        {
            var income = await _httpClient.GetFromJsonAsync<decimal>($"appointment/master/account/income?StartDate={dateRange.StartDate:yyyy-MM-dd}&EndDate={dateRange.EndDate:yyyy-MM-dd}");

            return new Result<decimal>(income);
        }

        public async Task<Result<IEnumerable<ManagerAppointment>>> GetManagerAppointments(Paging paging)
        {
            var appointments = await _httpClient.GetFromJsonAsync<IEnumerable<ManagerAppointment>>($"appointment/manager/account?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (appointments == null)
            {
                return new Result<IEnumerable<ManagerAppointment>>(new ServerException());
            }
            return new Result<IEnumerable<ManagerAppointment>>(appointments);
        }

        public async Task<Result<IEnumerable<AppointmentWithoutStatus>>> GetManagerActiveAppointments(Paging paging)
        {
            var appointments = await _httpClient.GetFromJsonAsync<IEnumerable<AppointmentWithoutStatus>>($"appointment/active/manager/account?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (appointments == null)
            {
                return new Result<IEnumerable<AppointmentWithoutStatus>>(new ServerException());
            }
            return new Result<IEnumerable<AppointmentWithoutStatus>>(appointments);
        }

        public async Task<Result<IEnumerable<AppointmentWithoutStatus>>> GetManagerCompletedAppointments(Paging paging)
        {
            var appointments = await _httpClient.GetFromJsonAsync<IEnumerable<AppointmentWithoutStatus>>($"appointment/completed/manager/account?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (appointments == null)
            {
                return new Result<IEnumerable<AppointmentWithoutStatus>>(new ServerException());
            }
            return new Result<IEnumerable<AppointmentWithoutStatus>>(appointments);
        }

        public async Task<Result<IEnumerable<AppointmentWithoutStatus>>> GetManagerUncompletedAppointments(Paging paging)
        {
            var appointments = await _httpClient.GetFromJsonAsync<IEnumerable<AppointmentWithoutStatus>>($"appointment/uncompleted/manager/account?PageNumber={paging.PageNumber}&PageSize={paging.PageSize}");

            if (appointments == null)
            {
                return new Result<IEnumerable<AppointmentWithoutStatus>>(new ServerException());
            }
            return new Result<IEnumerable<AppointmentWithoutStatus>>(appointments);
        }
    }
}
