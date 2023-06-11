using BeautySalonSite.Models.CityModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.CityService
{
    public class CityService : ICityService
    {
        private readonly HttpClient _httpClient;

        public CityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<string>> CreateCity(CityInput request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("city", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> DeleteCity(int cityId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"city/{cityId}");

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new Result<string>(new NotFoundException());
            }
            return new Result<string>(new ServerException());
        }

        public async Task<Result<IEnumerable<City>>> GetAllCities()
        {
            var cities = await _httpClient.GetFromJsonAsync<IEnumerable<City>>("city");

            if (cities == null)
            {
                return new Result<IEnumerable<City>>(new ServerException());
            }
            return new Result<IEnumerable<City>>(cities);
        }

        public async Task<Result<string>> UpdateCity(int cityId, CityInput request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"city/{cityId}", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new Result<string>(new NotFoundException());
            }
            return new Result<string>(new ServerException());
        }
    }
}
