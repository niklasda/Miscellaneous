using Gallio.Framework;
using Gallio.Framework.Pattern;
using MbUnit.Framework;

namespace MbUnitDemo.Tests.Extensions
{
    public class MyTestDecoratorAttribute : TestDecoratorAttribute
    {
        private readonly string message;
        public MyTestDecoratorAttribute(string msg)
        {
            message = msg;
        }

        protected override void Execute(PatternTestInstanceState testInstanceState)
        {
            TestLog.WriteLine("MyTestDecoratorAttribute.Execute");
            TestLog.WriteLine("Test name: {0}", testInstanceState.TestMethod.Name);
            TestLog.WriteLine("Message: {0}", message);

            base.Execute(testInstanceState);
        }

        protected override void SetUp(PatternTestInstanceState testInstanceState)
        {
            TestLog.WriteLine("MyTestDecoratorAttribute.SetUp");

            base.SetUp(testInstanceState);
        }

        protected override void TearDown(PatternTestInstanceState testInstanceState)
        {
            TestLog.WriteLine("MyTestDecoratorAttribute.TearDown");

            base.TearDown(testInstanceState);
        }
    }
}