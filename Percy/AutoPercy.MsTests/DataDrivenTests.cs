using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using AutoPercy.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoPercy.MsTests
{
    [TestClass]
    public class DataDrivenTests
    {
        private const string CsvFileName = @"Data\books.csv";

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", CsvFileName, "books#csv", DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            //"Author";"Title";"Publication Year";"Publisher";"Format";"ISBN";"Dewey";"Original Title";"Quantity";"Sub Title";"LoC Classification";"No. of Pages";"Language";"Owner";"Genre"
            string author = TestContext.DataRow["Author"].ToString();
            string title = TestContext.DataRow["Title"].ToString();
            string publicationYear = TestContext.DataRow["Publication Year"].ToString();
            string publisher = TestContext.DataRow["Publisher"].ToString();
            string format = TestContext.DataRow["Format"].ToString();
            string isbn = TestContext.DataRow["ISBN"].ToString();
            string dewey = TestContext.DataRow["Dewey"].ToString(); // price
            string originalTitle = TestContext.DataRow["Original Title"].ToString();
            string quantity = TestContext.DataRow["Quantity"].ToString();
            string subTitle = TestContext.DataRow["Sub Title"].ToString();
            string locClassification = TestContext.DataRow["LoC Classification"].ToString();
            string noOfPages = TestContext.DataRow["No# of Pages"].ToString();
            string language = TestContext.DataRow["Language"].ToString();
            string owner = TestContext.DataRow["Owner"].ToString();
            string genre = TestContext.DataRow["Genre"].ToString();
        }

        [TestInitialize]
        public void TestInit()
        {

            PercyManager.Instance.OpenSite();
            PercyManager.Instance.Login();
           // PercyManager.Instance.GotoAddBook();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            PercyManager.Instance.Logout();
        }

        public TestContext TestContext { get; set; }
    }
}
