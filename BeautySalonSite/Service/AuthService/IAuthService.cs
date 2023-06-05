using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.UserModels;
using System.Security.Claims;

namespace BeautySalonSite.Service.AuthService
{
    public interface IAuthService
    {
        Task<Result<string>> Logout();
        Task<Result<string>> Login(UserLogin request);
        Task<Result<string>> Register(ClientRegistration request);
        Task<Result<string>> ResetPassword(ResetPasswordRequest request);
        Task<Result<string>> GetUserRole();
    }
}
