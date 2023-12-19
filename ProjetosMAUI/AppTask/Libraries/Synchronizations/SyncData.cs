using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Libraries.Synchronizations
{
    public class SyncData
    {
        private static string _key = "sync.date";

        public static DateTimeOffset? GetLastSyncDate()
        {
            return Preferences.Default.Get<DateTimeOffset?>(_key, null);
        }
        public static void SetLastSyncDate(DateTimeOffset date)
        {
            Preferences.Default.Set(_key, date);
        }
    }
}
