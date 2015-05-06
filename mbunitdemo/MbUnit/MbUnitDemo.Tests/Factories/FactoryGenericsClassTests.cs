using System;
using System.Collections.Generic;
using Gallio.Framework;
using Gallio.Framework.Data;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Factories
{
    public class MyFactory
    {
        public static IEnumerable<Type> TypeGen()
        {
            yield return typeof(Person);
            yield return typeof(EquatablePerson);
            yield return typeof(ComparablePerson);
        }

        public static IEnumerable<string> NameGen()
        {
            yield return "Nils";
            yield return "Niklas";
        }

        public static IEnumerable<int> AgeGen()
        {
            yield return 10;
            yield return 100;
        }

        public static IEnumerable<object[]> MultiGenObjAr()
        {
            yield return new object[] { "Niklas", 22 };
        }

        public static IEnumerable<ListDataItem<object>> MultiGenListWithMetaData()
        {
            yield return new ListDataItem<object>(new List<object> { "Niklas", 22 }, new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("q", "My meta data value") }, false);
        }
    }

    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Factories)]
    public class FactoryGenericClassTests<[Factory(typeof(MyFactory), "TypeGen")] T>
        where T : IPerson, new()
    {
        [Test]
        public void TestFactoryClassGeneric(
            [Factory(typeof(MyFactory), "NameGen", ColumnCount = 1, Kind = FactoryKind.Object)] string name,
            [Factory(typeof(MyFactory), "AgeGen")] int age)
        {
            IPerson p = new T();
            p.Name = name;
            p.Age = age;

            TestLog.WriteLine(typeof(T));
            Assert.IsInstanceOfType(typeof(T), p);
        }





        [Test]
        [Factory(typeof(MyFactory), "MultiGenObjAr", ColumnCount = 2, Kind = FactoryKind.ObjectArray)]
        public void TestFactoryClassGenericRow(string name, int age)
        {
            IPerson p = new T();
            p.Name = name;
            p.Age = age;

            TestLog.WriteLine(typeof(T));
            Assert.IsInstanceOfType(typeof(T), p);
        }

        [Test]
        [Factory(typeof(MyFactory), "MultiGenListWithMetaData", ColumnCount = 2, Kind = FactoryKind.DataItem)]
        public void TestFactoryClassGenericRowf(string name, int age)
        {
            IPerson p = new T();
            p.Name = name;
            p.Age = age;

            string stepMetaValue = TestStep.CurrentStep.Metadata.GetValue("q");

            TestLog.WriteLine(stepMetaValue);
            TestLog.WriteLine(typeof(T));
            Assert.IsInstanceOfType(typeof(T), p);
        }
    }
}