using System.Text;

namespace AppTask.API.Libraries.Text
{
    public static class StringExtension
    {
        public static string GenerateHash(this string s, int length)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            for(int i = 0; i < length; i++)
            {
                sb.Append(random.Next());
            }

            return sb.ToString();
        }
    }
}
