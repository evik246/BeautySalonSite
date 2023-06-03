﻿using BeautySalonSite.Models.AppointmentModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.AppointmentService
{
    public interface IAppointmentService
    {
        Task<Result<IEnumerable<CustomerAppointment>>> GetActiveCustomerAppointments(int salonId, Paging paging);
    }
}