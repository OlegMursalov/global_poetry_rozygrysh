using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class PersonMySqlRepository : BaseMySqlRepository
    {
        public bool IsExist(string vk_id, string pass, out string errMessage)
        {
            errMessage = null;

            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();
                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT `vk_id`, `pass`");
                    sb.AppendLine("FROM `poets`");
                    sb.AppendLine($"WHERE `vk_id` = '{vk_id}' and `pass` = '{pass}'");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    using (var reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                errMessage = GetInfoByException(ex);
            }

            return false;
        }

        public void Create(string vk_id, string pass, string description, out string errMessage)
        {
            errMessage = null;

            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();
                    var sb = new StringBuilder();
                    sb.AppendLine($"INSERT INTO `poets`(`vk_id`, `pass`, `description`) VALUES ('{vk_id}','{pass}','{description}')");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    var i = myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                errMessage = GetInfoByException(ex);
            }
        }
    }
}