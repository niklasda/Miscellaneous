using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Configuration;

namespace HerrValuta
{
    public sealed partial class frmValuta : Form
    {
       // private string urlForex = "http://www.forex.se/index.asp";
       // private string urlDestination = string.Empty;
        
        private ValutaSettings settings = null;

        public frmValuta(string[] args)
        {
            InitializeComponent();

            GetAppSettings();
            
            if(settings.valutaAutoRun)
            {
                tDoItOnce.Enabled = true;
            }
            
            tbToUrl.Text = settings.valutaToUrl;
        }

        private void GetAppSettings()
        {
            settings = new ValutaSettings();
            settings.smtpServer = ConfigurationManager.AppSettings.Get("smtpServer");
            settings.smtpPort = int.Parse(ConfigurationManager.AppSettings.Get("smtpPort"));
            settings.smtpTo = ConfigurationManager.AppSettings.Get("smtpTo");
            settings.smtpFrom = ConfigurationManager.AppSettings.Get("smtpFrom");
            settings.smtpSubject = ConfigurationManager.AppSettings.Get("smtpSubject");
            settings.smtpBody = ConfigurationManager.AppSettings.Get("smtpBody");

            settings.valutaFromUrl = ConfigurationManager.AppSettings.Get("valutaFromUrl");
            settings.valutaToUrl = ConfigurationManager.AppSettings.Get("valutaToUrl");
            settings.valutaAutoRun = bool.Parse(ConfigurationManager.AppSettings.Get("valutaAutoRun"));
            settings.valutaAutoClose = bool.Parse(ConfigurationManager.AppSettings.Get("valutaAutoClose"));
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            getFromForex();
        }

        private void getFromForex()
        {
            string forexHtml = getUrl(settings.valutaFromUrl);

            double dEUR = parseValuta(forexHtml, "EUR");
            double dGBP = parseValuta(forexHtml, "GBP");
            double dNOK = parseValuta(forexHtml, "NOK");
            double dDKK = parseValuta(forexHtml, "DKK");

            tbEur.Text = dEUR.ToString();
            tbGbp.Text = dGBP.ToString();
            tbNok.Text = dNOK.ToString();
            tbDkk.Text = dDKK.ToString();
        }

        private double parseValuta(string forexHtml, string currencyCode)
        {
            int pos1;
            int pos2;
            string currencyValue;

            pos1 = forexHtml.IndexOf("notesitem[1] = \"" + currencyCode + "\";", 1, StringComparison.InvariantCultureIgnoreCase) + 24;
            pos1 = forexHtml.IndexOf("\"", pos1, StringComparison.InvariantCultureIgnoreCase) + 1;
            pos2 = forexHtml.IndexOf("\"", pos1, StringComparison.InvariantCultureIgnoreCase);

            currencyValue = forexHtml.Substring(pos1, pos2 - pos1);

            return double.Parse(currencyValue);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            putToDestination();
        }

        private void putToDestination()
        {
            string todayString = DateTime.Today.ToString("yyyMMdd");

            double dSEK = double.Parse(tbSek.Text);
            double dEUR = double.Parse(tbEur.Text);
            double dGBP = double.Parse(tbGbp.Text);
            double dNOK = double.Parse(tbNok.Text);
            double dDKK = double.Parse(tbDkk.Text);

            int dSEKpe = (int)((dSEK / dEUR) * 10000);
            int dGBPpe = (int)((dGBP / dEUR) * 10000);
            int dNOKpe = (int)((dNOK / dEUR) * 10000);
            int dDKKpe = (int)((dDKK / dEUR) * 10000);

            string siteUrl = settings.valutaToUrl;
            string url = siteUrl + "?datum=" + todayString + "&sek=" + dSEKpe + "&gbp=" + dGBPpe + "&nok=" + dNOKpe + "&dkk=" + dDKKpe;
            string response = getUrl(url);

            tbLog.AppendText(url + Environment.NewLine);
        }
        
        private string getUrl(string url)
        {
            tbLog.AppendText(url + Environment.NewLine);
            
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(wc.OpenRead(url));
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                tbLog.AppendText(ex.ToString() + Environment.NewLine);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return string.Empty;
        }

        private void btnClearMessages_Click(object sender, EventArgs e)
        {
            tbLog.Clear();
        }

        private void tDoItOnce_Tick(object sender, EventArgs e)
        {
            try
            {
                tbLog.AppendText("Timer!" + Environment.NewLine);
                tDoItOnce.Enabled = false;

                getFromForex();
                Application.DoEvents();

                putToDestination();
            }
            catch(Exception ex)
            {
                sendMail(ex.ToString());
            }
            finally
            {
                if(settings.valutaAutoClose)
                {
                    this.Close();
                }
            }
        }

        private void tbToUrl_TextChanged(object sender, EventArgs e)
        {
            TextBox tbUrlDestination = (TextBox)sender;
            settings.valutaToUrl = tbUrlDestination.Text;
        }
        
        private void sendMail(string fel)
        {
            sendMailToDavid(settings.smtpServer, settings.smtpPort, settings.smtpTo, settings.smtpFrom, settings.smtpSubject, settings.smtpBody, fel);
        }

        private void sendMailToDavid(string server, int port, string to, string from, string subject, string body, string mess)
        {
            MailMessage msg = new MailMessage(from, to, subject, body +" "+ mess);
            SmtpClient client = new SmtpClient(server, port);
            
            client.Send(msg);
        }

        private void bAuto_Click(object sender, EventArgs e)
        {
            tDoItOnce.Enabled = true;
        }

        private void bTestMail_Click(object sender, EventArgs e)
        {
            GetAppSettings();
            sendMail("This is a test");

        }
    }
}