using BeautySalonSite.Models.CityModels;
using BeautySalonSite.Models.Other;

namespace BeautySalonSite.Service.CityService
{
    public interface ICityService
    {
        Task<Result<IEnumerable<City>>> GetAllCities();
        Task<Result<string>> CreateCity(CityInput request);
        Task<Result<string>> UpdateCity(int cityId, CityInput request);
        Task<Result<string>> DeleteCity(int cityId);
    }
}
