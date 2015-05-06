using Microsoft.VisualStudio.TestTools.UnitTesting;

using RankWords.Parsing;

namespace RankWords.Tests.Parsing
{
    [TestClass]
    [DeploymentItem(@"TestFiles\")]
    public class HtmlParserTests
    {
        private const string FileName1 = @"TextFile1.txt";

        [TestMethod]
        public void TestHtmlParser1Found1HitUnder100Words()
        {
            IParser tp = new HtmlParser();

            var result = tp.Parse(FileName1);
            Assert.AreEqual(string.Empty, result.ErrorMessage);
            Assert.AreEqual(FileName1, result.FileName);
            Assert.AreEqual(1, result.Ranks["niklas"]); // not +1 because of small file
        }
    }
}
