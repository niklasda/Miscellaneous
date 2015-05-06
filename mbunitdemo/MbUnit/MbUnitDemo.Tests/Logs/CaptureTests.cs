using System.IO;
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
    public class CaptureTests
    {
        [Test]
        public void CapureVideoAndSave()
        {
            Capture.SetCaption("TestVideo");

            var cp = new CaptureParameters();
            cp.Zoom = 0.25;

            using (ScreenRecorder recording = Capture.StartRecording(cp, 2))
            {
                Thread.Sleep(5*1000);
                recording.Stop();

                Stream s = new FileStream("testvideo.flv", FileMode.Create);
                recording.Video.Save(s); // The video can be attached without saving
                s.Close();

                TestLog.AttachVideo("AttachedVideo", recording.Video);
                TestLog.EmbedVideo("EmbededVideo", recording.Video);
            }
        }
    }
}