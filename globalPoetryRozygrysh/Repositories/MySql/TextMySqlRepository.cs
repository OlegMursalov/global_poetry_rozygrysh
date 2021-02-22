using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace globalPoetryRozygrysh.Repositories.MySql
{
    public class TextMySqlRepository : BaseMySqlRepository
    {
        public void Save()
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