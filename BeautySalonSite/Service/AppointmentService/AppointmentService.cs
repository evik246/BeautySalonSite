using BeautySalonSite.Models.AppointmentModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
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
    }
}
