using System.Collections.Generic;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Factories)]
    public class DynamicTestFactoryDemo
        <[Factory(typeof(TheFactory), "TypeGen")] T>
        where T : IPerson, new()
    {
        private int perTypeCount;


        [DynamicTestFactory]
        [Row("Niklas", 35)]
        [Row("Nils", 36)]
        public IEnumerable<Test> CreateDynamicTestSuite(string name, int age)
        {
            int perSuiteCount = 0;
            var suite = new TestSuite("SimpleDynamicTestSuite")
                {
                    Description = "TestSuite for T=" + typeof (T).Name,
                    SetUp = () => 
                                {
                                    perSuiteCount++;
                                    perTypeCount++;
                                    TestLog.WriteLine("Setup");
                                },
                    TearDown = () => TestLog.WriteLine("TearDown"),
                    SuiteSetUp = () =>
                                     {
                                         perSuiteCount = 0;
                                         TestLog.WriteLine("SuiteSetup");
                                     },
                    SuiteTearDown = () => TestLog.WriteLine("SuiteTearDown"),
                    Children =
                    {
                    }
            }; 


            for(int i=1 ; i<=5; i++)
            {
                var tcName = new TestCase("TestCaseName_" + name +"_"+ i, ()=>
                {
                    IPerson p = new T();
                    p.Name = name;

                    TestLog.WriteLine("Setting Name={0} Suite={1} Class={2}", name, perSuiteCount, perTypeCount);
                    Assert.AreEqual(p.Name, name);
                });

                var tcAge = new TestCase("TestCaseAge_" + age + "_" + i, () =>
                {
                    IPerson p = new T();
                    p.Age = age;

                    TestLog.WriteLine("Setting Age={0} Suite={1} Class={2}", age, perSuiteCount, perTypeCount);
                    Assert.AreEqual(p.Age, age);
                });

                suite.Children.Add(tcName);
                suite.Children.Add(tcAge);
            }

            yield return suite;
        }
    }
}