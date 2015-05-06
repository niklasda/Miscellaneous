using System.IO;
using AutoPercy.Logic;
using Gallio.Framework;
using MbUnit.Framework;

namespace AutoPercy.Tests
{
    [TestFixture]
    [CsvData(FilePath = CsvFileName, HasHeader = true, FieldDelimiter = ',')]
    public class PercyTests
    {
        private const string CsvFileName = @"Data\books.csv";

        [FixtureSetUp]
        public void VerifyAndOpen()
        {
            StreamReader reader = File.OpenText(CsvFileName);
            string line = reader.ReadLine();
            Assert.IsNotNull(line, "File must contain at least 2 line, whereof one is header");

            line = reader.ReadLine();
            reader.Close();
            Assert.IsNotNull(line, "File must contain at least 2 line, whereof one is header");

            PercyManager.Instance.OpenSite();
            PercyManager.Instance.Login();
            PercyManager.Instance.GotoAddBook();
        }

        [FixtureTearDown]
        public void CloseDown()
        {
            PercyManager.Instance.Logout();
        }

        [Test]
        public void PercyManagerDataTest(string author, string title, string publicationYear, string publisher, string format, string isbn, string dewey, string originalTitle, 
                                         string quantity, string subTitle, string locClassification, string noOfPages, string language, string owner, string genre)
        {
            Assert.IsNotNull(author);
            Assert.IsNotNull(title);
            Assert.IsNotNull(publicationYear);
            Assert.IsNotNull(publisher);
            Assert.IsNotNull(format);
            Assert.IsNotNull(isbn);
            Assert.IsNotNull(dewey);
            Assert.IsNotNull(originalTitle);
            Assert.IsNotNull(quantity);
            Assert.IsNotNull(subTitle);
            Assert.IsNotNull(locClassification);
            Assert.IsNotNull(noOfPages);
            Assert.IsNotNull(language);
            Assert.IsNotNull(owner);
            Assert.IsNotNull(genre);


            TestLog.WriteLine("Adding {0} by {1}", title, author);

            PercyManager.Instance.AddBookStep1(author, title, publicationYear, publisher, format, isbn, dewey, originalTitle, quantity, subTitle, locClassification, noOfPages, language, genre);
        }
    }
}
