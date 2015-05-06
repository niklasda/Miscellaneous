using Gallio.Framework;
using Gallio.Framework.Data;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Factories)]
    public class FactoryGenericClassTests
        <[Factory(typeof(TheFactory), "TypeGen")] T>
        where T : IPerson, new()
    {
        [Test]
        [SequentialJoin]
        public void TestFactoryClassGeneric(
            [Factory(typeof(TheFactory), "NameGen", 
                ColumnCount = 1, 
                Kind = FactoryKind.Object)] 
            string name,
            [Factory(typeof(TheFactory), "AgeGen")] 
            int age)
        {
            IPerson p = new T();
            p.Name = name;
            p.Age = age;

            TestLog.WriteLine(typeof(T));
            Assert.IsInstanceOfType(typeof(T), p);
        }
    }
}