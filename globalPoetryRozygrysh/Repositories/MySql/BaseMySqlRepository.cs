using System;
using System.Configuration;
using System.Text;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class BaseMySqlRepository
    {
        protected readonly string _connectionString;

        public BaseMySqlRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnectionStr"].ConnectionString;
        }

        protected string GetInfoByException(Exception ex)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ex.Message);
            sb.AppendLine(ex.StackTrace);
            return sb.ToString();
        }

        protected string GetUTF8String(string myString)
        {
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(myString);
            return UTF8Encoding.UTF8.GetString(bytes);
        }
    }
}