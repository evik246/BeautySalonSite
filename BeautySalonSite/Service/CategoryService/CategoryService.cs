using BeautySalonSite.Models.CategoryModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
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

        public async Task<Result<string>> ChangeCategory(int categoryId, CategoryInput request)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"category/{categoryId}", request);
                if (response.IsSuccessStatusCode)
                {
                    return new Result<string>("Success");
                }
                return new Result<string>(new ServerException());
            }
            catch (Exception ex)
            {
                return new Result<string>(new ServerException(ex.Message));
            }
        }

        public async Task<Result<string>> CreateCategory(CategoryInput request)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("category", request);
                if (response.IsSuccessStatusCode)
                {
                    return new Result<string>("Success");
                }
                return new Result<string>(new ServerException());
            }
            catch (Exception ex)
            {
                return new Result<string>(new ServerException(ex.Message));
            }
        }

        public async Task<Result<string>> DeleteCategory(int categoryId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"category/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    return new Result<string>("Success");
                }
                return new Result<string>(new ServerException());
            }
            catch (Exception ex)
            {
                return new Result<string>(new ServerException(ex.Message));
            }
        }

        public async Task<Result<IEnumerable<Category>>> GetAllCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("category");
            if (categories == null)
            {
                return new Result<IEnumerable<Category>>(new ServerException());
            }
            return new Result<IEnumerable<Category>>(categories);
        }

        public async Task<Result<IEnumerable<Category>>> GetManagerCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("category/manager/account");
            if (categories == null)
            {
                return new Result<IEnumerable<Category>>(new ServerException());
            }
            return new Result<IEnumerable<Category>>(categories);
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
