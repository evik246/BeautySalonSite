using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.ErrorModels;
using BeautySalonSite.Models.ExceptionModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.UserModels;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace BeautySalonSite.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly HttpClient _httpClient;

        private readonly string _storageItemName = "token";

        public AuthService(ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
            _httpClient = httpClient;
        }

        public async Task<Result<string>> GetUserRole()
        {
            var state = await _authStateProvider.GetAuthenticationStateAsync();
            var role = state.User.Claims
                .Where(c => c.Type.Equals("role"))
                .Select(c => c.Value)
                .First();
            if (role == null)
            {
                return new Result<string>(new NotFoundException());
            }
            return new Result<string>(role);
        }

        public async Task<Result<string>> Login(UserLogin request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("auth/login", request);

            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                await _localStorage.SetItemAsync(_storageItemName, token);
                await _authStateProvider.GetAuthenticationStateAsync();

                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new Result<string>(new UnauthorizedException());
            }

            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> Logout()
        {
            await _localStorage.RemoveItemAsync(_storageItemName);
            await _authStateProvider.GetAuthenticationStateAsync();
            return new Result<string>("Success");
        }

        public async Task<Result<string>> Register(ClientRegistration request)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("customer/register", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var error = await response.Content.ReadFromJsonAsync<Error>();

                if (error is not null && error.Message.Equals("This email is already used"))
                {
                    return new Result<string>(new UsedEmailException());
                }

                if (error is not null && error.Message.Equals("This phone number is already used"))
                {
                    return new Result<string>(new UsedPhoneException());
                }
            }
            return new Result<string>(new ServerException());
        }

        public async Task<Result<string>> ResetPassword(ResetPasswordRequest request)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync("customer/account/reset_password", request);

            if (response.IsSuccessStatusCode)
            {
                return new Result<string>("Success");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return new Result<string>(new UnauthorizedException());
            }

            return new Result<string>(new ServerException());
        }
    }
}
