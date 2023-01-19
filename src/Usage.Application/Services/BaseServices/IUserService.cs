using Ocdata.Operations.Authentication;

namespace Usage.Application.Services.BaseServices
{
    public interface IUserService
    {
        Task<LoginModel> GetUserDetails(string accountName);
        Task<bool> IsValidUserInformation(string username, string password);
    }
}