using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BeautySalonSite.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _authStateProvider.GetAuthenticationStateAsync();
        }
    }
}
