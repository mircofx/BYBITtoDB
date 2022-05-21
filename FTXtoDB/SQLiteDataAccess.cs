using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FTX.Net.Objects.Models;

namespace FTXtoDB
{
    public class SQLiteDataAccess
    {
        public static void SaveCandles(FTXKline kline, string Ticker)
        {
            using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

            string tick = Ticker.Replace("-", "");

            cnn.Execute($"insert into {tick} (startTime, open, close, high, low, volume) values (" +
                $"'{kline.OpenTime}', '{kline.OpenPrice}', '{kline.ClosePrice}', '{kline.HighPrice}', '{kline.LowPrice}', '{kline.Volume}')");
        }


        public static void BulkInsert(IOrderedEnumerable<FTXKline> data, string Ticker)
        {
            try
            {
                using IDbConnection cnn = new SQLiteConnection(LoadConnectionString());

                string tick = Ticker.Replace("-", "");

                var tables = cnn.Execute($"create table if not exists {tick} (startTime STRING, open DECIMAL, close DECIMAL, high DECIMAL, low DECIMAL, volume DECIMAL,  unique (startTime))");

                cnn.Open();

                using (var transaction = cnn.BeginTransaction())
                {
                    using (var command = cnn.CreateCommand())
                    {
                        command.CommandText =
                            $"insert or ignore into {tick}(startTime, open, close, high, low, volume) " +
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
                            startParameter.Value = contact.OpenTime;
                            openParameter.Value = contact.OpenPrice;
                            closeParameter.Value = contact.ClosePrice;
                            highParameter.Value = contact.HighPrice;
                            lowParameter.Value = contact.LowPrice;
                            volumeParameter.Value = contact.Volume;
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception occurred", $"{e.Message}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            string connectionString = $"Data Source = {Program.path}";

            return connectionString;
        }
    }
}
