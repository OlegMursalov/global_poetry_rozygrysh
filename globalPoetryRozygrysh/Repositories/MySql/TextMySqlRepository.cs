using globalPoetryRozygrysh.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class TextMySqlRepository : BaseMySqlRepository
    {
        public List<LyricsDto> Get(string vk_id, out string errMessage)
        {
            errMessage = null;
            var list = new List<LyricsDto>();

            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();
                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT `id`, `vk_id`, `value`");
                    sb.AppendLine("FROM `lyrics`");
                    sb.AppendLine($"WHERE `vk_id` = '{vk_id}'");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    using (var reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(new LyricsDto
                                {
                                    id = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0,
                                    vk_id = !reader.IsDBNull(1) ? reader.GetString(1) : null,
                                    value = GetUTF8String(!reader.IsDBNull(2) ? reader.GetString(2) : null)
                                });
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

            return list;
        }

        public void SaveAll(string vk_id, string[] lyrics, out string errMessage)
        {
            errMessage = null;

            try
            {
                for (int i = 0; i < lyrics.Length; i++)
                {
                    if (IsExistText(vk_id, i, out errMessage))
                    {
                        Update(vk_id, i, lyrics[i], out errMessage);
                    }
                    else
                    {
                        Create(vk_id, i, lyrics[i], out errMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                errMessage = GetInfoByException(ex);
            }
        }

        private void Create(string vk_id, int i, string value, out string errMessage)
        {
            errMessage = null;

            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();

                    var sb = new StringBuilder();
                    sb.AppendLine($"INSERT INTO `lyrics`(`id`, `vk_id`, `value`) VALUES ('{i}','{vk_id}','{value}')");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    var x = myCommand.ExecuteNonQuery();

                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                errMessage = GetInfoByException(ex);
            }
        }

        private void Update(string vk_id, int i, string value, out string errMessage)
        {
            errMessage = null;

            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();

                    var sb = new StringBuilder();
                    sb.AppendLine($"UPDATE `lyrics` SET `value`='{value}' WHERE `vk_id`='{vk_id}' and `id`='{i}'");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    var x = myCommand.ExecuteNonQuery();

                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                errMessage = GetInfoByException(ex);
            }
        }

        private bool IsExistText(string vk_id, int i, out string errMessage)
        {
            bool result = false;
            errMessage = null;

            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();

                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT `id`");
                    sb.AppendLine("FROM `lyrics`");
                    sb.AppendLine($"WHERE `vk_id` = '{vk_id}' and `id` = '{i}'");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);

                    using (var reader = myCommand.ExecuteReader())
                    {
                        result = reader.HasRows;
                    }

                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                errMessage = GetInfoByException(ex);
            }

            return result;
        }
    }
}