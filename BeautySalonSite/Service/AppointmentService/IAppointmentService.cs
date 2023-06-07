using BeautySalonSite.Models.AppointmentModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ScheduleModels;

namespace BeautySalonSite.Service.AppointmentService
{
    public interface IAppointmentService
    {
        Task<Result<IEnumerable<CustomerAppointment>>> GetActiveCustomerAppointments(int salonId, Paging paging);
        Task<Result<CustomerAppointment>> GetCustomerAppointmentById(int appointmentId);
        Task<Result<string>> CancelCustomerAppointment(int appointmentId);
        Task<Result<string>> MakeCustomerAppointment(CustomerAppointmentCreate request);
        Task<Result<IEnumerable<MasterAppointment>>> GetMasterAppointments(Paging paging);
        Task<Result<string>> MarkMasterAppointmentComplete(int appointmentId);
        Task<Result<string>> MarkManagerAppointmentCompleted(int appointmentId);
        Task<Result<int>> GetMasterAppointmentCount(DateRange dateRange);
        Task<Result<decimal>> GetMasterAppointmentIncome(DateRange dateRange);
        Task<Result<IEnumerable<ManagerAppointment>>> GetManagerAppointments(Paging paging);
        Task<Result<IEnumerable<AppointmentWithoutStatus>>> GetManagerActiveAppointments(Paging paging);
        Task<Result<IEnumerable<AppointmentWithoutStatus>>> GetManagerCompletedAppointments(Paging paging);
        Task<Result<IEnumerable<AppointmentWithoutStatus>>> GetManagerUncompletedAppointments(Paging paging);
        Task<Result<string>> ChangeMasterInAppointment(int appointmentId, int masterId);
        Task<Result<ManagerAppointment>> GetManagerAppointmentById(int appointmentId);
    }
}
