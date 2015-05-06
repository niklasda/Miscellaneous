

namespace HerrValuta
{
    class ValutaSettings
    {
        public string smtpServer;
        public int smtpPort;
        public string smtpTo;
        internal string smtpFrom;
        public string smtpSubject;
        public string smtpBody;

        public string valutaFromUrl;
        public string valutaToUrl;
        public bool valutaAutoClose;
        public bool valutaAutoRun;
    }
}
