using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ScheduleModels;

namespace BeautySalonSite.Service.ScheduleService
{
    public interface IScheduleService
    {
        Task<Result<IEnumerable<MasterWorkingDay>>> GetMasterWorkingDays(int masterId, DateOnly startDate, DateOnly endDate);
        Task<Result<IEnumerable<MasterAvailableSlot>>> GetMasterAvailableSlots(int masterId, int serviceId, DateOnly date);
        Task<Result<IEnumerable<MasterSchedule>>> GetMasterSchedule();
        Task<Result<IEnumerable<MasterSchedule>>> GetManagerMasterSchedule(int masterId);
        Task<Result<string>> ChangeManagerMasterSchedule(int scheduleId, MasterScheduleChange request);
        Task<Result<string>> CreateManagerMasterSchedule(int masterId, MasterScheduleCreate request);
    }
}
