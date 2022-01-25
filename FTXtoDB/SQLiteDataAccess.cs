using FTX.Net.Objects.Spot;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FTXtoDB
{
    public class SQLiteDataAccess
    {
        public static void SaveCandles(FTXKline kline, string Ticker)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            string tick = Ticker.Replace("-", "");

            cnn.Execute($"insert into {tick} (startTime, open, close, high, low, volume) values (" +
                $"'{kline.StartTime}', '{kline.Open}', '{kline.Close}', '{kline.High}', '{kline.Low}', '{kline.Volume}')");
        }

        public static void BulkInsert(IOrderedEnumerable<FTXKline> data, string Ticker)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            string tick = Ticker.Replace("-", "");

            cnn.Open();

            using (var transaction = cnn.BeginTransaction())
            {
                using (var command = cnn.CreateCommand())
                {
                    command.CommandText =
                        $"insert into {tick}(startTime, open, close, high, low, volume) " +
                        "values ($startTime, $open, $close, $high, $low, $volume);";

                    var startParameter = command.CreateParameter();
                    startParameter.ParameterName = "$startTime";
                    command.Parameters.Add(startParameter);

                    var openParameter = command.CreateParameter();
                    openParameter.ParameterName = "$open";
                    command.Parameters.Add(openParameter);

                    var closeParameter = command.CreateParameter();
                    closeParameter.ParameterName = "$close";
                    command.Parameters.Add(closeParameter);

                    var highParameter = command.CreateParameter();
                    highParameter.ParameterName = "$high";
                    command.Parameters.Add(highParameter);

                    var lowParameter = command.CreateParameter();
                    lowParameter.ParameterName = "$low";
                    command.Parameters.Add(lowParameter);

                    var volumeParameter = command.CreateParameter();
                    volumeParameter.ParameterName = "$volume";
                    command.Parameters.Add(volumeParameter);

                    foreach (var contact in data)
                    {
                        startParameter.Value = contact.StartTime;
                        openParameter.Value = contact.Open;
                        closeParameter.Value = contact.Close;
                        highParameter.Value = contact.High;
                        lowParameter.Value = contact.Low;
                        volumeParameter.Value = contact.Volume;
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
           
        }

        private static string LoadConnectionString(string id = "Default")
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FTXdata.db");

            string connectionString = $"Data Source = {path}";

            return connectionString;
        }
    }
}
