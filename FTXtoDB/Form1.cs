using Bybit.Net.Clients;
using Bybit.Net.Enums;
using Bybit.Net.Objects;
using Bybit.Net.Objects.Models;
using CryptoExchange.Net.Authentication;
using System.Data;
using System.Linq;
using System.Management;
using System.Security;
using static BybittoDB.SQLiteDataAccess;

namespace BybittoDB
{
    public partial class Form1 : Form
    {
        public static BybitClient? client;
        public static int quantity;
        public Form1()
        {
            InitializeComponent();

            ResolutionPopulate();

            Tuple<SecureString, SecureString> keys = EncryptCredentials("VBXQYZOEZBIJCTQABS", "USRVQOXBSFNKRPXHSJKGWNDSZIGVNRGZDEQG");

            client = new(new BybitClientOptions()
            {
                UsdPerpetualApiOptions = new() 
                {
                    ApiCredentials = new ApiCredentials(keys.Item1, keys.Item2)
                }
            });

            quantity = (int)crownNumeric1.Value;

            GetListInstruments(client);
        }

        public void GetListInstruments(BybitClient client)
        {
            var list = client.UsdPerpetualApi.ExchangeData.GetSymbolsAsync().Result.Data;

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

        private void btnParseDate_Click(object sender, EventArgs e)
        {

            if (Program.path == "")
            {
                MessageBox.Show("You didn't select the output database.", "Bybit Parser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ParseEverything(dateTimePicker1.Value);
            }
        }

        private void crownNumeric1_ValueChanged(object sender, EventArgs e)
        {
            quantity = (int)crownNumeric1.Value;
        }

        private async Task ParseEverything(DateTime? startDateParse)
        {
            List<BybitKline> candles = new();
            //IEnumerable<BybitKline> result = new List<BybitKline>();

            bool run = true;

            //KlineInterval s = KlineInterval.FifteenSeconds;
            KlineInterval s = KlineInterval.OneMinute;
            string ticker = cbTickers.SelectedItem.ToString();

            DateTime startDate = DateTime.UtcNow;
            DateTime endDate = DateTime.UtcNow;

            Progress<ProgressReport> progress = new();

            try
            {
                while (run)
                {
                    switch (cbResolutions.SelectedItem)
                    {
                        //case ("15s"):
                        //    s = KlineInterval.FifteenSeconds;
                        //    int seconds = -15 * quantity;
                        //    endDate = startDate;
                        //    startDate = startDate.AddSeconds(seconds);
                        //    break;
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



                    var result = Task.Run(async() => await client.UsdPerpetualApi.ExchangeData.GetKlinesAsync(ticker, s, startDate)).Result; //MAX 1500 candles
                    
                    if (startDate < startDateParse)
                    {
                        result = Task.Run(async () => await client.UsdPerpetualApi.ExchangeData.GetKlinesAsync(ticker, s, startDate)).Result; //MAX 1500 candles
                    }

                    if (result.Data.Count() == 0)
                    {
                        run = false;
                        var db = candles.OrderBy(o => o.OpenTime);
                        string name = ticker + cbResolutions.SelectedItem.ToString().ToUpper();
                        ProcessData(db, name);
                        labelProgress.Text = "Done!";
                        MessageBox.Show("I successfully parsed all the candles you requested.", "Completed", MessageBoxButtons.OK);
                    }
                    else
                    {
                        //progress.PercentComplete = index++ * 100 / totalProcess;
                        //progress.Report(progressReport);
                        labelProgress.Text = "Working...";
                        //progress.ProgressChanged += (o, report) => {
                        //    labelProgress.Text = String.Format($"Processing...{report.PercentComplete}");
                        //    progressBar1.Value = report.PercentComplete;
                        //    progressBar1.Update();
                        //};

                        IEnumerable<BybitKline> ftxklines = result.Data.OrderByDescending(o => o.OpenTime);
                        var c = ftxklines.ToList();
                        candles.AddRange(c);
                        if (startDateParse != null)
                        {
                            if (startDate < startDateParse)
                            {
                                var db = candles.OrderBy(o => o.OpenTime);
                                string name = ticker + cbResolutions.SelectedItem.ToString().ToUpper();
                                ProcessData(db, name);
                                labelProgress.Text = "Done!";
                                MessageBox.Show("I successfully parsed all the candles you requested.", "Completed", MessageBoxButtons.OK);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error occurred.{e.Message}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void UpdateBar(IProgress<ProgressReport> progress)
        //{
        //    int index = 1;
        //    int totalProcess = list.Count();
        //    var progressReport = new ProgressReport();
        //}
        

        private void ProcessData(IOrderedEnumerable<BybitKline> list, string ticker)
        {
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

        private void btnParseAll_Click(object sender, EventArgs e)
        {
            if (Program.path == "")
            {
                MessageBox.Show("You didn't select the output database.", "Bybit Parser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ParseEverything(null);
            }
        }

        private void locateDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.ShowDialog();

            if (!fileDialog.FileNames.FirstOrDefault().Contains(".db"))
            {
                MessageBox.Show("The selected file is not a .db file.\nPlease select .db.", "Not a database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Program.path = fileDialog.FileNames.FirstOrDefault();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var uno = MessageBox.Show("You just got TROLLED!🤌", "MEGALOL!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (uno == DialogResult.No)
            {
                var due = MessageBox.Show("You got yourself in this situation u you that right?!", "Whaaaat???😠", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (due == DialogResult.No)
                {
                    var tre = MessageBox.Show("Lol now whatever you press will switch off the pc", "F U 😠", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (tre == DialogResult.Yes || tre == DialogResult.No)
                    {
                        Shutdown();
                    }
                }
                else
                {
                    var tre = MessageBox.Show("I value your honesty more than your curiosity.\nKeep working!", "Good boy!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                }
            }
            else
            {
                var due = MessageBox.Show("I value your honesty more than your curiosity.\nKeep working!", "Good boy!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            }
        }

        void Shutdown()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }
    }
}