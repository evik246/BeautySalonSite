using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.SalonModels;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.SalonService
{
    public class SalonService : ISalonService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        private readonly string _storageitemName = "salonid";

        public SalonService(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public async Task<Result<int>> GetSalonIdFromLocalStorage()
        {
            var stringId = await _localStorage.GetItemAsStringAsync(_storageitemName);
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

        public async Task<Result<IEnumerable<SalonWithOnlyAddress>>> GetSalonsWithAddress()
        {
            var salons = await _httpClient.GetFromJsonAsync<IEnumerable<SalonWithOnlyAddress>>("salon");

            if (salons is null)
            {
                return new Result<IEnumerable<SalonWithOnlyAddress>>(new ServerException());
            }
            return new Result<IEnumerable<SalonWithOnlyAddress>>(salons);
        }

        public async Task RemoveSalonIdFromLocalStorage()
        {
            await _localStorage.RemoveItemAsync(_storageitemName);
        }

        public async Task SetSalonIdInLocalStorage(int salonId)
        {
            if (salonId <= 0)
            {
                await _localStorage.RemoveItemAsync(_storageitemName);
            }
            else
            {
                await _localStorage.SetItemAsync(_storageitemName, salonId);
            }
        }

        public async Task<Result<SalonWithOnlyAddress>> GetSalonWithAddressById(int salonId)
        {
            var salon = await _httpClient.GetFromJsonAsync<SalonWithOnlyAddress>($"salon/{salonId}");

            if (salon is not null)
            {
                return new Result<SalonWithOnlyAddress>(salon);
            }

            return new Result<SalonWithOnlyAddress>(new NotFoundException());
        }
    }
}
