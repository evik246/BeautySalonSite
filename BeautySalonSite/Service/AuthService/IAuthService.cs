using BeautySalonSite.Models.CustomerModels;
using BeautySalonSite.Models.Other;
using BeautySalonSite.Models.UserModels;

namespace BeautySalonSite.Service.AuthService
{
    public interface IAuthService
    {
        Task<Result<string>> Logout();
        Task<Result<string>> Login(UserLogin request);
        Task<Result<string>> Register(ClientRegistration request);
    }
}
