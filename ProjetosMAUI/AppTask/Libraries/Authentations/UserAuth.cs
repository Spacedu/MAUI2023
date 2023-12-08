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
        public static void SetUserLogged(UserModel user)
        {
            var userJson = JsonSerializer.Serialize(user);
            Preferences.Default.Set("user.logged", userJson);
        }

        public static UserModel GetUserLogged()
        {
            var userJson = Preferences.Default.Get<string>("user.logged", String.Empty);
            if (string.IsNullOrEmpty(userJson))
                return null;

            return JsonSerializer.Deserialize<UserModel>(userJson);
        }
    }
}
