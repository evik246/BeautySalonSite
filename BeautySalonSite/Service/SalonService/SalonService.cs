using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using Blazored.LocalStorage;

namespace BeautySalonSite.Service.SalonService
{
    public class SalonService : ISalonService
    {
        private readonly ILocalStorageService _localStorage;

        public SalonService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task<Result<int>> GetSalonIdFromLocalStorage()
        {
            var stringId = await _localStorage.GetItemAsStringAsync("salonid");
            if (stringId is not null)
            {
                stringId = stringId.Replace("\"", "");
                if (int.TryParse(stringId, out int salonId))
                {
                    return new Result<int>(salonId);
                }
            }
            return new Result<int>(new NotFoundException());
        }
    }
}
