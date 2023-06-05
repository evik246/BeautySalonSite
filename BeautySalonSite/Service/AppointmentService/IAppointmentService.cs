﻿using BeautySalonSite.Models.AppointmentModels;
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
        Task<Result<int>> GetMasterAppointmentCount(DateRange dateRange);
        Task<Result<decimal>> GetMasterAppointmentIncome(DateRange dateRange);
    }
}
