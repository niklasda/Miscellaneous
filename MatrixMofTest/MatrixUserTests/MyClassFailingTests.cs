using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;

namespace Tests
{
    [TestClass]
    public class FailTest
    {
        [TestMethod]
        public void FailMockTest()
        {
            Mock<IMyClass> mock = new Mock<IMyClass>();
            IMyClass mc = mock.Instance;
            MyClassUser mcu = new MyClassUser(mc);

            int returnValue = 123;
            object[] args = new object[] { new int[8, 8] };
            mock.Implement("GetAreaSize", args, returnValue);
            int size = mcu.GetAreaSize(new int[8, 9]);
            Assert.AreEqual(returnValue, size);
        }
    }

    public interface IMyClass
    {
        int GetAreaSize(int[,] area);
    }

    public class MyClass : IMyClass
    {
        public int GetAreaSize(int[,] area)
        {
            int size = area.GetLength(0) * area.GetLength(1);
            return size;
        }
    }

    public class MyClassUser
    {
        public MyClassUser(IMyClass pmyClass)
        {
            myClass = pmyClass;
        }
        private IMyClass myClass;

        public int GetAreaSize(int[,] ints)
        {
            return myClass.GetAreaSize(ints);
        }
    }
}
