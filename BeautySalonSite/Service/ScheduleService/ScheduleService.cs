using BeautySalonSite.Models.ErrorModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.ScheduleModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace BeautySalonSite.Service.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly HttpClient _httpClient;

        public ScheduleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<string>> ChangeManagerMasterSchedule(int scheduleId, MasterScheduleChange request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"schedule/{scheduleId}/manager/account", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            var error = await response.Content.ReadFromJsonAsync<Error>();

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                if (error != null && error.Message.Contains("The number of working hours exceeds the maximum limit"))
                {
                    return new Result<string>(new OutOfTimeLimitException());
                }
            }
            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> CreateManagerMasterSchedule(int masterId, MasterScheduleCreate request)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"schedule/manager/account/master/{masterId}", request);

                if (response.IsSuccessStatusCode)
                {
                    return new Result<string>("Success");
                }

                var error = await response.Content.ReadFromJsonAsync<Error>();

                if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    if (error != null && error.Message.Contains("The number of working hours exceeds the maximum limit"))
                    {
                        return new Result<string>(new OutOfTimeLimitException());
                    }
                }
                return new Result<string>(new ServerException());
            }
            catch(Exception ex)
            {
                return new Result<string>(new ServerException(ex.Message));
            }
        }

        public async Task<Result<IEnumerable<MasterSchedule>>> GetManagerMasterSchedule(int masterId)
        {
            var schedule = await _httpClient.GetFromJsonAsync<IEnumerable<MasterSchedule>>($"schedule/manager/account/master/{masterId}");

            if (schedule == null)
            {
                return new Result<IEnumerable<MasterSchedule>>(new ServerException());
            }
            return new Result<IEnumerable<MasterSchedule>>(schedule);
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

        public async Task<Result<IEnumerable<MasterSchedule>>> GetMasterSchedule()
        {
            var schedule = await _httpClient.GetFromJsonAsync<IEnumerable<MasterSchedule>>("schedule/master/account");

            if (schedule == null)
            {
                return new Result<IEnumerable<MasterSchedule>>(new ServerException());
            }
            return new Result<IEnumerable<MasterSchedule>>(schedule);
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
