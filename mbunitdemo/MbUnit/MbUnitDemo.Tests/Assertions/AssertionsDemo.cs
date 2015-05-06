using System;
using System.Collections.Generic;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Assertions
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Assertions)]
    public class AssertionsDemo
    {
        [Test]
        [Importance(Importance.Serious)]
        public void DemoLotsOfAssertions()
        {            
            TestLog.WriteLine("DemoAssertions");
            
            Assert.AreApproximatelyEqual(40, 41, 2);
            Assert.AreElementsEqual(new[] { "a", "b", "c" }, new[] { "a", "b", "c" });
            Assert.AreElementsEqualIgnoringOrder(new[] { "a", "c", "b" }, new[] { "a", "b", "c" });
            Assert.AreElementsNotEqual(new[] { "a", "b", "c" }, new[] { "i", "j", "k" });
            Assert.AreEqual("nop", "nop");
            Assert.AreEqual("nop", "nop", (x, y) => x.Length == y.Length);
            Assert.AreEqual(new[,] { { 0, 1 }, { 0, 1 } }, new[,] { { 0, 1 }, { 0, 1 } });
            Assert.AreNotApproximatelyEqual(40, 42, 1);
            Assert.AreNotEqual("aa", "bb");
            Assert.AreNotSame("asd", "asd2");
            Assert.AreSame("asd", "asd");
            Assert.Between(40, 37, 43);
            Assert.Contains("Niklas", "kl");
            Assert.Contains(new[] { "a", "b", "c" }, "a");
            Assert.ContainsKey(new Dictionary<string, string> { { "key", "value" } }, "key");
            Assert.Count(3, new[] {1, 2, 3}); // new in 3.2
            Assert.Distinct(new[] { 1, 2, 3, 4 });
            Assert.DoesNotContain("Niklas", "apa");
            Assert.DoesNotContain(new[] { "a", "b", "c" }, "p");
            Assert.DoesNotContainKey(new Dictionary<string, string> { { "key", "value" } }, "nonkey");
            Assert.DoesNotThrow(() => { });
            Assert.EndsWith("Niklas", "as");
            Assert.Exists(new[] { 2, 3, 4, 5, 6 }, x => x % 2 == 0, "No number not even"); // new in 3.1
            Assert.ForAll(new[] { 2, 4, 6 }, x => x % 2 == 0, "All numbers were even");   // new in 3.1
            Assert.FullMatch("Niklas", "Niklas");
            Assert.GreaterThan(12, 10);
            Assert.GreaterThanOrEqualTo(12, 10);
            Assert.IsAssignableFrom(typeof(string), "asd".GetType());
            Assert.IsEmpty(new string[] { });
            Assert.IsFalse(false);
            Assert.IsInstanceOfType(typeof(string), "asd");
            Assert.IsNotAssignableFrom(typeof(string), 12.GetType());
            Assert.IsNotEmpty(new[] { "a" });
            Assert.IsNotInstanceOfType(typeof(string), 12);
            Assert.IsNotNull("not");
            Assert.IsNull(null);
            Assert.IsTrue(true);
            Assert.LessThan(1, 2);
            Assert.LessThanOrEqualTo(3, 3);
            Assert.Like("Niklas", "[a-zA-Z]");
            Assert.Multiple(() => { });
            Assert.NotBetween(10, 20, 22);
            Assert.NotLike("Niklas", "[bcdefgh]");
            Assert.Sorted(new[] { 1, 2, 2, 3, 4 }, SortOrder.Increasing);
            Assert.Sorted(new[] { 1, 2, 3, 4 }, SortOrder.StrictlyIncreasing);
            Assert.StartsWith("Niklas", "Ni");
            Assert.Throws<ArgumentNullException>(() => { throw new ArgumentNullException(); });
            
            Assert.Over.Pairs(new[] { "aZ", "bZ", "cZ" }, new[] { "a", "b", "c" }, Assert.StartsWith);
            Assert.Over.KeyedPairs(new Dictionary<string, string> { { "key", "value" } }, new Dictionary<string, string> { { "key", "val" } }, Assert.StartsWith);

            Assert.Xml.AreEqual("<XmlTag></XmlTag>", "<XmlTag />", XmlOptions.Loose);
            Assert.Xml.Exists("<XmlTag><Niklas/></XmlTag>", "/XmlTag", XmlOptions.Strict);
            Assert.Xml.IsUnique("<XmlTag/>", "/XmlTag", XmlOptions.Strict);

            string xml = Assert.XmlSerialize(new Person());
            Assert.StartsWith(xml, "<Person");
            Assert.EndsWith(xml, "</Person>");
        }

        [Test]
        [Description("Show the diff in Icarus")]
        [Importance(Importance.Severe)]
        public void DemoNonSuccessAssertion()
        {
            Assert.AreEqual("Niklas", "Níklas");
        }

        [Test]
        [Importance(Importance.Critical)]
        [DependsOn("DemoLotsOfAssertions")]
        public void Demo35Assertions()
        {
            TestLog.WriteLine(".NET 3.5 Assertions");

            AssertEx.That(() => "Niklas".Contains("as"));
        }
    }
}