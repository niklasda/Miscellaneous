using System.IO;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.DataDriven
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.DataDriven)]
    [CsvData(FilePath = CsvFileName, HasHeader = true)]
    public class CsvDataDrivenTests
    {
        private const string CsvFileName = @"Files\Persons.csv";

        [FixtureSetUp]
        public void VerifyFile()
        {
            StreamReader reader = File.OpenText(CsvFileName);
            string line = reader.ReadLine();
            Assert.IsNotNull(line);
            line = reader.ReadLine();
            reader.Close();
            Assert.IsNotNull(line, "File must contain at least 2 line, whereof one is header");
        }

        [Test]
        public void TestOnCsvData(string name, int age)
        {
            Assert.AreEqual("Niklas", name);
            Assert.AreEqual(32, age);
        }

        [Test]
        public void TestOnCsvData2(string name, int age)
        {
            Assert.AreNotEqual("NiklasX", name);
            Assert.AreNotEqual(24, age);
        }

    }
}