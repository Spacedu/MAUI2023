using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppTask.Libraries.Synchronizations
{
    public class SyncData
    {
        private static string _key = "sync.date";

        public static DateTimeOffset? GetLastSyncDate()
        {
            var dateJson = Preferences.Default.Get<string>(_key, null);

            return (dateJson is null) ? null : JsonSerializer.Deserialize<DateTimeOffset?>(dateJson);
        }
        public static void SetLastSyncDate(DateTimeOffset date)
        {
            var dateJson = JsonSerializer.Serialize(date);
            Preferences.Default.Set(_key, dateJson);
        }
    }
}
