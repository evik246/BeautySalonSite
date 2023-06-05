using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ScheduleModels;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly HttpClient _httpClient;

        public ScheduleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<MasterAvailableSlot>>> GetMasterAvailableSlots(int masterId, int serviceId, DateOnly date)
        {
            var availableSlots = await _httpClient.GetFromJsonAsync<IEnumerable<MasterAvailableSlot>>($"schedule/timeslots/available?MasterId={masterId}&ServiceId={serviceId}&Date={date:yyyy-MM-dd}");
            if (availableSlots == null )
            {
                return new Result<IEnumerable<MasterAvailableSlot>>(new ServerException());
            }
            return new Result<IEnumerable<MasterAvailableSlot>>(availableSlots);
        }

        public async Task<Result<IEnumerable<MasterWorkingDay>>> GetMasterWorkingDays(int masterId, DateOnly startDate, DateOnly endDate)
        {
            var workingDays = await _httpClient.GetFromJsonAsync<IEnumerable<MasterWorkingDay>>($"schedule/master/{masterId}/working_days?StartDate={startDate:yyyy-MM-dd}&EndDate={endDate:yyyy-MM-dd}");
            if (workingDays == null )
            {
                return new Result<IEnumerable<MasterWorkingDay>>(new ServerException());
            }
            return new Result<IEnumerable<MasterWorkingDay>>(workingDays);
        }
    }
}
