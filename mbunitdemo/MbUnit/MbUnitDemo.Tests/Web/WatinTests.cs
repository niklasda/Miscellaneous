using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;
using WatiN.Core;
using WatiN.Core.Logging;
using WatiN.Core.Interfaces;
using WatiN.Core.Native.Windows;
using Gallio.Common.Media;

namespace MbUnitDemo.Tests.Web
{
    public abstract class WatiNFixture
    {
        protected Browser TheBrowser { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Logger.LogWriter = new GallioLogger();

            Capture.SetCaptionAlignment(HorizontalAlignment.Center, VerticalAlignment.Bottom);
            Capture.SetCaptionFontSize(38);
            Capture.AutoEmbedRecording(TriggerEvent.TestFailedOrInconclusive,
                                       "Screen Recording",
                                       new CaptureParameters { Zoom = 0.33 }, 5 /*frames per second*/);

            TheBrowser = new IE();
            TheBrowser.ShowWindow(NativeMethods.WindowShowStyle.ShowMaximized);
        }

        [TearDown]
        public void TearDown()
        {
            Capture.SetCaption("");

            var ie = TheBrowser as IE;
            if (ie != null)
            {
                ie.Close();
            }
        }

        private sealed class GallioLogger : ILogWriter
        {
            public void LogAction(string message)
            {
                Capture.SetCaption(message);
                TestLog.WriteLine(message);
            }

            public void LogInfo(string message)
            {
                TestLog.WriteLine(message);
            }

            public void LogDebug(string message)
            {
                // Ignore these messages.
            }
        }
    }

    [TestFixture]
    [Category(Categories.Watin)]
    public class SampleTest : WatiNFixture
    {
        [Test]
        public void GoogleSearchAndVisitMaps()
        {
            TheBrowser.GoTo("http://www.google.se");

            TheBrowser.TextField(Find.ByName("q")).TypeText("Ottawa");
            TheBrowser.Button(Find.ByName("btnG")).Click();

            TheBrowser.Link(Find.ByText("Ottawa, ON Kanada")).Click();

            TheBrowser.Link(Find.ByText("Colline du Parlement")).Click();

            TheBrowser.Link(Find.ByText("Hela artikeln")).Click();

            Assert.Fail("Just for show.");
        }
    }
}