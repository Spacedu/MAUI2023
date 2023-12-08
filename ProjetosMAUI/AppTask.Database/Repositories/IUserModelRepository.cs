using AppTask.Models;

namespace AppTask.Database.Repositories
{
    public interface IUserModelRepository
    {
        void Add(UserModel user);
        UserModel GetByEmail(string email);
        void Update(UserModel user);
    }
}