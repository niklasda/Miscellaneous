using System;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Verifiers
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Verifiers)]
    public class AccessorTest
    {
        [VerifyContract]
        public readonly IContract AccessorTester = new AccessorContract<Person, string>
          {
              AcceptNullValue = false,
              PropertyName = "Name",
              ValidValues =
                  {
                      "TestName1",
                      "TestName2"
                  },
              DefaultInstance = () => new Person("DefaultPerson", 25),
              InvalidValues =
                  {
                      new InvalidValuesClass<string>(typeof(ArgumentNullException))
                          {
                              ""
                          }
                  }
          };
    }
}