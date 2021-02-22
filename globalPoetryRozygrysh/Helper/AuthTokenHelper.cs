using System;
using System.Text;

namespace globalPoetryRozygrysh.Helper
{
    public static class AuthTokenHelper
    {
        public static string Generate(string vk_id)
        {
            var sb = new StringBuilder();
            foreach (var i in Reverse(vk_id))
            {
                sb.Append((int)i);
            }
            return sb.ToString();
        }

        public static bool Check(string vk_id, string token)
        {
            return Generate(vk_id) == token;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}