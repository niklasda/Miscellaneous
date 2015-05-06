using Gallio.Ambience;
using Gallio.Framework;
using MbUnit.Framework;
using System.Linq;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Persistence
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Persistence)]
    [Description("Illustrates the bad practice of storing state between tests")]
    public class PersistenceDataTests
    {
        [Test(Order = 1)]
        public void StoreDataTest()
        {
            TestLog.Write("Database Config: ");
            TestLog.Write(Ambient.DefaultClientConfiguration.HostName);
            TestLog.Write(":");
            TestLog.Write(Ambient.DefaultClientConfiguration.Port);
            TestLog.Write(" as ");
            TestLog.WriteLine(Ambient.DefaultClientConfiguration.Credential.UserName);

            Ambient.Data.Store(new Person("AmbientPerson", 88));
        }

        [Test(Order = 2)]
        [DependsOn("StoreDataTest")]
        public void RetrieveDataTest()
        {
            Person p = (from Person person in Ambient.Data where person.Age == 88 select person).First();

            Assert.IsNotNull(p);
        }

        [Test(Order = 3)]
        [DependsOn("RetrieveDataTest")]
        public void DeleteDataTest()
        {
            Ambient.Data.DeleteAll();

        }
    }
}
