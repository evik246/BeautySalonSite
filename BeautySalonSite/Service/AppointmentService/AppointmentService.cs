using BeautySalonSite.Models.AppointmentModels;
using BeautySalonSite.Models.ErrorModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;

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
            string jsonRequest = JsonSerializer.Serialize(request);

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

            return new Result<string>(new ServerException(error.Message));
        }
    }
}
