using globalPoetryRozygrysh.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class TextMySqlRepository : BaseMySqlRepository
    {
        public IEnumerable<LyricsDto> Get(string vk_id, out string errMessage)
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
                                    value = !reader.IsDBNull(2) ? reader.GetString(2) : null
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

        public void Save(string vk_id, string lyrics)
        {
            /*using (var myConnection = new MySqlConnection(_connectionString))
            {
                myConnection.Open();
                var sb = new StringBuilder();
                sb.AppendLine("UPDATE `usbreleportsettings`");
                var timesJson = JsonConvert.SerializeObject(usbRelePortSettingsDto.Times);
                var installDate = usbRelePortSettingsDto.InstallDate;
                var recurrencyDay = usbRelePortSettingsDto.RecurrencyDay;
                sb.AppendLine($"SET `OpenSecAmount`={usbRelePortSettingsDto.OpenSecAmount},`Times`=`{timesJson}`,`InstallDate`=`{installDate}`,`RecurrencyDay`=`{recurrencyDay}`");
                sb.AppendLine($"WHERE `Id` = {usbRelePortSettingsDto.Id}");
                var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }*/
        }
    }
}