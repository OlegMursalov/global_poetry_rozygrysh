using globalPoetryRozygrysh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Text;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class PersonMySqlRepository : BaseMySqlRepository
    {
        public AuthDto Get(string vk_id, out string errMessage)
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
                    sb.AppendLine($"WHERE `vk_id` = '{vk_id}'");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    using (var reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new AuthDto
                                {
                                    vk_id = !reader.IsDBNull(0) ? reader.GetString(0) : null,
                                    pass = !reader.IsDBNull(1) ? reader.GetString(1) : null
                                };
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

            return null;
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