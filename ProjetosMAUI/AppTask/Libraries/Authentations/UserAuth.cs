using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppTask.Libraries.Authentations
{
    public class UserAuth
    {
        private static string _key = "user.logged";
        public static void SetUserLogged(UserModel user)
        {
            var userJson = JsonSerializer.Serialize(user);
            Preferences.Default.Set(_key, userJson);
        }

        public static UserModel GetUserLogged()
        {
            var userJson = Preferences.Default.Get<string>(_key, String.Empty);
            if (string.IsNullOrEmpty(userJson))
                return null;

            return JsonSerializer.Deserialize<UserModel>(userJson);
        }

        public static void Logout()
        {
            if (Preferences.Default.ContainsKey(_key))
            {
                Preferences.Default.Remove(_key);
            }
        }
    }
}
