using Microsoft.VisualStudio.TestTools.UnitTesting;

using RankWords.Parsing;

namespace RankWords.Tests.Parsing
{
    [TestClass]
    [DeploymentItem(@"TestFiles\")]
    public class BothParserTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles1.xml", "file", DataAccessMethod.Random)]
        public void TestParser1Found1HitUnder100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(1, result.Ranks["niklas"]); // not +1 because of small file
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles2.xml", "file", DataAccessMethod.Random)]
        public void TestParser2Found9HitsOver100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(10, result.Ranks["niklas"]); // the +1 for big files is added at parser (=file) level
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles2.xml", "file", DataAccessMethod.Random)]
        public void TestParser2Found10LetterWord10HitsOver100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(10, result.Ranks["jjjjjjjjjj"]); // the +1 for big files is added at parser (=file) level
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles2.xml", "file", DataAccessMethod.Random)]
        public void TestParser2Found11LetterWord10HitsOver100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(10, result.Ranks["kkkkkkkkkkk"]); // all hit counted at parser (=file) level, only at controller level will they be filtered out
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles2.xml", "file", DataAccessMethod.Random)]
        public void TestParser2Found11LetterDashedWord10HitsOver100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(10, result.Ranks["lllll-llllll"]); // all hit counted at parser (=file) level, only at controller level will they be filtered out
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles2.xml", "file", DataAccessMethod.Random)]
        public void TestParser2Found20LetterDashedWord10HitsOver100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(10, result.Ranks["mmmmmmmmmm-mmmmmmmmmm"]); // all hit counted at parser (=file) level, only at controller level will they be filtered out
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles2.xml", "file", DataAccessMethod.Random)]
        public void TestParser2Found1LetterWord10HitsOver100Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(10, result.Ranks["a"]); // all hit counted at parser (=file) level, only at controller level will they be filtered out
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles3.xml", "file", DataAccessMethod.Random)]
        public void TestParser3Found1LetterWord10HitsOver1000Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName); 
            Assert.AreEqual(100, result.Ranks["a"]); // 99 occurances in file, +1 for 100+ wordfile, but no +1 for 1000+ file and double letter
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TextFiles3.xml", "file", DataAccessMethod.Random)]
        public void TestParser3Found2LetterWord10HitsOver1000Words()
        {
            var fileName = TestContext.DataRow["file_Text"].ToString();

            var tp = ParserFactory.GetParser(fileName);
            var result = tp.Parse(fileName);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(fileName, result.FileName);
            Assert.AreEqual(101, result.Ranks["bb"]); // 99 occurances in file, +1 for 100+ wordfile, and +1 for 1000+ file and double letter
        }
    }
}
