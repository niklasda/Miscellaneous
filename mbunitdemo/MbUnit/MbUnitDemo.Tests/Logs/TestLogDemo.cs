using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Gallio.Common.Markup;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Logs
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Logs)]
    public class TestLogDemo
    {
        [Test]
        public void DemoEmbedTestLog()
        {
            using (TestLog.BeginSection("My Embed Section"))
            {
                const string html = "<b>bold statement</b>";
                TestLog.EmbedHtml("HTML Attachment 2", html);

                string fileName = Path.Combine(Environment.CurrentDirectory, @"Files\pic.jpg");
                TestLog.EmbedImage("Image attachment", Image.FromFile(fileName));
                // must be serializable        
                TestLog.EmbedObjectAsXml("ObjectAsXml attachment", new ImmutablePerson("name", 21));

                using (TestLog.BeginMarker(Marker.Highlight))
                {
                    TestLog.WriteLine("Cool with a highlighted section");
                    TestLog.WriteEllipsis();
                    TestLog.WriteLine();
                }

                Marker m = Marker.Exception;
                using (TestLog.BeginMarker(m))
                {
                    var ageEx = new AgeException();
                    TestLog.WriteException(ageEx);
                }
            }
        }

        [Test]
        public void DemoAttachTestLog()
        {
            using (TestLog.BeginSection("My Outer Section"))
            {
                using (TestLog.BeginSection("My Inner Upper Section"))
                {
                    const string html = "<b>bold statement</b>";
                    TextAttachment a = Attachment.CreateHtmlAttachment("HTML Attachment 1", html);
                    TestLog.Attach(a);

                    TestLog.AttachHtml("HTML Attachment 2", html);

                    string fileName = Path.Combine(Environment.CurrentDirectory, @"Files\pic.jpg");
                    TestLog.AttachImage("Image attachment", Image.FromFile(fileName));
                    // must be serializable        
                    TestLog.AttachObjectAsXml("ObjectAsXml attachment", new ImmutablePerson("name", 21));
                    TestLog.AttachPlainText("Plain text attachment", "a little text");
                    TestLog.AttachXml("XML Attachement", "<Person />");

                    using (TestLog.BeginMarker(Marker.Highlight))
                    {
                        TestLog.Write("Cool with a highlighted marking");
                        TestLog.WriteEllipsis();
                        TestLog.WriteLine();
                    }

                    Marker m = Marker.Exception;
                    using (TestLog.BeginMarker(m))
                    {
                        var ageEx = new AgeException();
                        TestLog.WriteException(ageEx);
                    }
                }
                using (TestLog.BeginSection("My Inner Lower Section"))
                {
                    TestLog.WriteLine("More information");
                }
            }
        }
      
        [Test]
        public void DemoTestLogVideo()
        {
            using (TestLog.BeginSection("My Video Section"))
            {
                using (ScreenRecorder recording = Capture.StartRecording())
                {
                    Thread.Sleep(2*1000);
                    recording.Stop();

                    TestLog.AttachVideo("AttachedVideo", recording.Video);
                    TestLog.EmbedVideo("EmbededVideo", recording.Video);
                }
            }
        }
    }
}