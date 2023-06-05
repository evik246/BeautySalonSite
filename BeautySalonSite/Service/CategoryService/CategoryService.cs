using BeautySalonSite.Models.CategoryModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BeautySalonSite.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<IEnumerable<Category>>> GetMasterCategories(int masterId)
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>($"category/master/{masterId}");
            if (categories == null)
            {
                return new Result<IEnumerable<Category>>(new ServerException());
            }
            return new Result<IEnumerable<Category>>(categories);
        }

        public async Task<Result<IEnumerable<Category>>> GetSalonCategories(int salonId)
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>($"category/salon/{salonId}");
            if (categories == null)
            {
                return new Result<IEnumerable<Category>>(new ServerException());
            }
            return new Result<IEnumerable<Category>>(categories);
        }
    }
}
