using AppTask.Models;

namespace AppTask.Services
{
    public interface IUserService
    {
        Task<UserModel> GetAccessToken(string email);
        Task<UserModel> ValidateAccessToken(UserModel userModel);
    }
}