using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Database.Repositories
{
    public class UserModelRepository : IUserModelRepository
    {
        private AppTaskContext _db;
        public UserModelRepository()
        {
            _db = new AppTaskContext();
        }
        public UserModel GetByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public void Add(UserModel user)
        {
            _db.Users.Add(user);

            _db.SaveChanges();
        }

        public void Update(UserModel user)
        {
            _db.Users.Update(user);

            _db.SaveChanges();
        }
    }
}
