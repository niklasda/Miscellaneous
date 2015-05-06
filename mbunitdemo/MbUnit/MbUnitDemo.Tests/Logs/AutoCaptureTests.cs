using System.Threading;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Logs
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Logs)]
    public class AutoCaptureTests
    {
        [Test]
        public void AutoCapureVideoAndEmbed()
        {
            TestContext.CurrentContext.AutoExecute(TriggerEvent.TestFailedOrInconclusive,
                () => TestLog.EmbedImage("TestCaptureScreenshot", Capture.Screenshot()));
        }

        [Test]
        public void CapureVideoAndAutoEmbed()
        {
            Capture.SetCaption("TestAutoEmbedVideo");

            var cp = new CaptureParameters { Zoom = 0.25 };

            Capture.AutoEmbedRecording(TriggerEvent.TestPassedOrInconclusive, "AutoEmbededVideo", cp, 5);
            Thread.Sleep(5 * 1000);

            Assert.IsNull(null);
        }

        [Test]
        public void CapureImageAndAutoEmbed()
        {
            Capture.SetCaption("TestAutoEmbedScreenshot");

            var cp = new CaptureParameters { Zoom = 0.25 };

            Capture.AutoEmbedScreenshot(TriggerEvent.TestPassedOrInconclusive, "AutoEmbededScreenshot", cp);
            Thread.Sleep(5 * 1000);

            Assert.IsNull(null);
        }

    }
}