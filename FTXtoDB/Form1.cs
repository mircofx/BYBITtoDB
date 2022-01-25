using CryptoExchange.Net.Authentication;
using FTX.Net;
using FTX.Net.Enums;
using FTX.Net.Objects;
using FTX.Net.Objects.Spot;
using System.Data;
using System.Linq;
using System.Security;
using static FTXtoDB.SQLiteDataAccess;

namespace FTXtoDB
{
    public partial class Form1 : Form
    {
        public static FTXClient client;
        public static int quantity;
        public Form1()
        {
            InitializeComponent();

            ResolutionPopulate();

            Tuple<SecureString, SecureString> keys = EncryptCredentials("Y0pKVmOYI1l9TDEiYR_EtI7FexlNUAU20_dBnbcC", "E64JMLW1Ql0sZsZpkpZosBCPCRAdDG09Jz0SsZCr");

            client = new(new FTXClientOptions()
            {
                ApiCredentials = new ApiCredentials(keys.Item1, keys.Item2),
                SubaccountName = "Gold",
                AffiliateCode = "BullBots",
                AutoTimestamp = false
            });

            quantity = (int)crownNumeric1.Value;

            GetListInstruments(client);
        }

        public void GetListInstruments(FTXClient client)
        {
            var list = client.GetFuturesAsync().Result.Data;

            List<string> tickers = list.Select(s => s.Name).ToList();

            cbTickers.DataSource = tickers;
        }

        public void ResolutionPopulate()
        {
            List<string> resolutions = new() { 
                "15s",
                "1m",
                "5m",
                "15m",
                "1h",
                "4h",
                "24h"
            };

            cbResolutions.DataSource = resolutions;
        }

        private Tuple<SecureString, SecureString> EncryptCredentials(string apikey, string apisecret)
        {
            SecureString secureKey = new();
            SecureString secureSecret = new();

            foreach (var c in apikey.ToCharArray()) secureKey.AppendChar(c);
            foreach (var c in apisecret.ToCharArray()) secureSecret.AppendChar(c);

            return new Tuple<SecureString, SecureString>(secureKey, secureSecret);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KlineInterval s = KlineInterval.FifteenSeconds;
            string ticker = cbTickers.SelectedItem.ToString();

            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = DateTime.UtcNow;

            

            switch (cbResolutions.SelectedItem)
            {
                case ("15s"):
                    s = KlineInterval.FifteenSeconds;
                    int seconds = -15 * quantity;
                    startDate = startDate.AddSeconds(seconds);
                    break;
                case ("1m"):
                    s = KlineInterval.OneMinute;
                    int minutes = -quantity;
                    startDate = startDate.AddMinutes(minutes);
                    break;
                case ("5m"):
                    s = KlineInterval.FiveMinutes;
                    int fives = -5 * quantity;
                    startDate = startDate.AddMinutes(fives);
                    break;
                case ("15m"):
                    s = KlineInterval.FifteenMinutes;
                    int fifteens = -15 * quantity;
                    startDate = startDate.AddMinutes(fifteens);
                    break;
                case ("1h"):
                    s = KlineInterval.OneHour;
                    int ones = -quantity;
                    startDate = startDate.AddHours(ones);
                    break;
                case ("4h"):
                    s = KlineInterval.FourHours;
                    int fours = -4 * quantity;
                    startDate = startDate.AddHours(fours);
                    break;
                case ("1d"):
                    s = KlineInterval.OneDay;
                    int days = -quantity;
                    startDate = startDate.AddDays(days);
                    break;
                case ("1w"):
                    s = KlineInterval.OneWeek;
                    int weeks = -quantity;
                    startDate = startDate.AddDays(weeks);
                    break;
                case ("1M"):
                    s = KlineInterval.OneMonth;
                    int months = -quantity;
                    startDate = startDate.AddMonths(months);
                    break;
            }

            var result = client.GetKlinesAsync(ticker, s, startDate, endDate).Result; //MAX 1500 candles

            var candles = result.Data;
        }

        private void crownNumeric1_ValueChanged(object sender, EventArgs e)
        {
            quantity = (int)crownNumeric1.Value;
        }

        private async Task ParseEverything()
        {
            List<FTXKline> candles = new List<FTXKline>();
            //IEnumerable<FTXKline> result = new List<FTXKline>();

            bool run = true;

            KlineInterval s = KlineInterval.FifteenSeconds;
            string ticker = cbTickers.SelectedItem.ToString();

            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = DateTime.UtcNow;

            while (run)
            {
                switch (cbResolutions.SelectedItem)
                {
                    case ("15s"):
                        s = KlineInterval.FifteenSeconds;
                        int seconds = -15 * quantity;
                        endDate = startDate;
                        startDate = startDate.AddSeconds(seconds);
                        break;
                    case ("1m"):
                        s = KlineInterval.OneMinute;
                        int minutes = -quantity;
                        endDate = startDate;
                        startDate = startDate.AddMinutes(minutes);
                        break;
                    case ("5m"):
                        s = KlineInterval.FiveMinutes;
                        int fives = -5 * quantity;
                        endDate = startDate;
                        startDate = startDate.AddMinutes(fives);
                        break;
                    case ("15m"):
                        s = KlineInterval.FifteenMinutes;
                        int fifteens = -15 * quantity;
                        endDate = startDate;
                        startDate = startDate.AddMinutes(fifteens);
                        break;
                    case ("1h"):
                        s = KlineInterval.OneHour;
                        int ones = -quantity;
                        endDate = startDate;
                        startDate = startDate.AddHours(ones);
                        break;
                    case ("4h"):
                        s = KlineInterval.FourHours;
                        int fours = -4 * quantity;
                        endDate = startDate;
                        startDate = startDate.AddHours(fours);
                        break;
                    case ("1d"):
                        s = KlineInterval.OneDay;
                        int days = -quantity;
                        endDate = startDate;
                        startDate = startDate.AddDays(days);
                        break;
                    case ("1w"):
                        s = KlineInterval.OneWeek;
                        int weeks = -quantity;
                        endDate = startDate;
                        startDate = startDate.AddDays(weeks);
                        break;
                    case ("1M"):
                        s = KlineInterval.OneMonth;
                        int months = -quantity;
                        endDate = startDate;
                        startDate = startDate.AddMonths(months);
                        break;
                }

                var result = client.GetKlinesAsync(ticker, s, startDate, endDate).Result; //MAX 1500 candles

                if (result.Data.Count() == 0)
                {
                    labelProgress.Text = "Working...";
                    var progress = new Progress<ProgressReport>();
                    progress.ProgressChanged += (o, report) => {
                        labelProgress.Text = String.Format($"Processing...{report.PercentComplete}");
                        progressBar1.Value = report.PercentComplete;
                        progressBar1.Update();
                    };

                    run = false;
                    var db = candles.OrderBy(o => o.StartTime);
                    string name = ticker + cbResolutions.SelectedItem.ToString().ToUpper();
                    ProcessData(db, progress, name);
                    labelProgress.Text = "Done!";
                }
                else
                {
                    IEnumerable<FTXKline> ftxklines = result.Data.OrderByDescending(o => o.StartTime);
                    var c = ftxklines.ToList();
                    candles.AddRange(c);
                }
            }
        }

        

        private void ProcessData(IOrderedEnumerable<FTXKline> list, IProgress<ProgressReport> progress, string ticker)
        {
            int index = 1;
            int totalProcess = list.Count();
            var progressReport = new ProgressReport();

            
            BulkInsert(list, ticker);

            //return Task.Run(() =>
            //{
            //    for (int i = 0; i < totalProcess; i++)
            //    {
                    
            //        SaveCandles(list.ElementAt(i), ticker);
                    
            //        progressReport.PercentComplete = index++ * 100 / totalProcess;
            //        progress.Report(progressReport);
            //    }
            //});
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await ParseEverything();
        }
    }
}