using System;
using System.Drawing;
using System.IO;
using Gallio.Common.Markup;
using Gallio.Common.Media;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
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
                TestLog.EmbedHtml("HTML Attachment", html);

                string fileName = Path.Combine(Environment.CurrentDirectory, @"Files\pic.jpg");
                TestLog.EmbedImage("Image attachment", 
                    Image.FromFile(fileName));

                using (TestLog.BeginMarker(Marker.Highlight))
                {
                    TestLog.Write("Cool with a highlighted section");
                    TestLog.WriteEllipsis();
                    TestLog.WriteLine();
                }
                TestLog.WriteLine();

                using (TestLog.BeginMarker(Marker.Exception))
                {
                    var ageEx = new AgeException();
                    TestLog.WriteException(ageEx);
                }
            }
        }





        [Test]
        public void DemoCaptureEmbedTestLog()
        {
            using (TestLog.BeginSection("My Capture Section"))
            {
                Bitmap pic = Capture.Screenshot(new CaptureParameters
                                       {
                                           Zoom = 0.2
                                       });
                TestLog.EmbedImage("A screenshot", pic);
            }
        }
    }
}