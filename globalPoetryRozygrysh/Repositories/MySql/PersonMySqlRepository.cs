using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class PersonMySqlRepository : BaseMySqlRepository
    {
        public UsbRelePortSettingsDto[] Find(string vk_id, string pass)
        {
            try
            {
                using (var myConnection = new MySqlConnection(_connectionString))
                {
                    myConnection.Open();
                    var sb = new StringBuilder();
                    sb.AppendLine("SELECT `Id`, `OpenSecAmount`, `InstallDate`, `RecurrencyDay`, `Times`");
                    sb.AppendLine("FROM `usbreleportsettings`");
                    var myCommand = new MySqlCommand(GetUTF8String(sb.ToString()), myConnection);
                    using (var reader = myCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                result.Add(new UsbRelePortSettingsDto
                                {
                                    Id = reader.GetInt32(1),
                                    OpenSecAmount = !reader.IsDBNull(1) ? reader.GetInt32(1) : 0,
                                    InstallDate = !reader.IsDBNull(2) ? reader.GetDateTime(2) : DateTime.Now,
                                    RecurrencyDay = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0,
                                    Times = !reader.IsDBNull(4) ? JsonConvert.DeserializeObject<DateTime[]>(reader.GetString(4)) : new DateTime[0]
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

            return result.ToArray();
        }

        public void Update(UsbRelePortSettingsDto usbRelePortSettingsDto)
        {
            using (var myConnection = new MySqlConnection(_connectionString))
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
            }
        }
    }
}