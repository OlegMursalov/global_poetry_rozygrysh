using System.Text;

namespace globalPoetryRozygrysh.Helper
{
    public static class AuthTokenHelper
    {
        public static string Generate(string vk_id)
        {
            var sb = new StringBuilder();
            foreach (var i in vk_id)
            {
                sb.Append((int)i);
            }
            return sb.ToString();
        }

        public static bool Check(string vk_id, string token)
        {
            return Generate(vk_id) == token;
        }
    }
}