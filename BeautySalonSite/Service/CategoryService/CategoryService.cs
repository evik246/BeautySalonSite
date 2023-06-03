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
        private readonly ILocalStorageService _localStorage;

        public CategoryService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<Result<IEnumerable<Category>>> GetCategories(int salonId)
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
