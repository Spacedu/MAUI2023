using AppTask.Models;

namespace AppTask.Services
{
    internal interface IUserService
    {
        Task<UserModel> GetAccessToken(string email);
        Task<UserModel> ValidateAccessToken(UserModel userModel);
    }
}