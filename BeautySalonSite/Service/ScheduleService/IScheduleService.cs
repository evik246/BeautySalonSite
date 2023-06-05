using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ScheduleModels;

namespace BeautySalonSite.Service.ScheduleService
{
    public interface IScheduleService
    {
        Task<Result<IEnumerable<MasterWorkingDay>>> GetMasterWorkingDays(int masterId, DateOnly startDate, DateOnly endDate);
        Task<Result<IEnumerable<MasterAvailableSlot>>> GetMasterAvailableSlots(int masterId, int serviceId, DateOnly date);
    }
}
