using BeautySalonSite.Models.AppointmentModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.AppointmentService
{
    public interface IAppointmentService
    {
        Task<Result<IEnumerable<CustomerAppointment>>> GetActiveCustomerAppointments(int salonId, Paging paging);
        Task<Result<CustomerAppointment>> GetCustomerAppointmentById(int appointmentId);
        Task<Result<string>> CancelCustomerAppointment(int appointmentId);
        Task<Result<string>> MakeCustomerAppointment(CustomerAppointmentCreate request);
    }
}
