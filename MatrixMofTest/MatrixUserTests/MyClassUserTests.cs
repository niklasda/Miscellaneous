using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;
using MatrixUser;

namespace MatrixUserTests
{
    [TestClass]
    public class MyClassUserTests
    {
        [TestMethod]
        public void MyClassUserTest()
        {
            IMyClass mc = new MyClass();
            MyClassUser mcu = new MyClassUser(mc);

            int size = mcu.GetAreaSize(new int[8, 9]);
            Assert.AreEqual(72, size);
        }

        [TestMethod]
        public void MyClassUserIntTest()
        {
            IMyClass3 mc = new MyClass3();
            MyClassUser3 mcu = new MyClassUser3(mc);
            
            int returnValue = 32;

            int size = mcu.GetInt();
            Assert.AreEqual(returnValue, size);
        }

        [TestMethod]
        public void MyClassUserIntMockTest()
        {
            Mock<IMyClass3> mock = new Mock<IMyClass3>();
            IMyClass3 mc = mock.Instance;
            MyClassUser3 mcu = new MyClassUser3(mc);

            int returnValue = 32;
            mock.Implement("GetInt", returnValue);

            int size = mcu.GetInt();
            Assert.AreEqual<int>(returnValue, size);
        }


        [TestMethod]
        public void MyClassUserJaggedMockTest()
        {
            Mock<IMyClass2> mock = new Mock<IMyClass2>();
            IMyClass2 mc = mock.Instance;
            MyClassUser2 mcu = new MyClassUser2(mc);

            int returnValue = 123;
            object[] args = new object[] { MockConstraint.IsAnything<int[][]>() };
            mock.Implement("GetAreaSize", args, returnValue);

            int size = mcu.GetAreaSize(createJaggedArray(8, 9));
            Assert.AreEqual(returnValue, size);
        }

        [TestMethod]
        public void MyClassUserMatrixMockTest()
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

        private int[][] createJaggedArray(int width, int height)
        {
            int[][] positions = new int[width][];

            for (int x = 0; x < width; x++)
            {
                positions[x] = new int[height];
            }

            return positions;
        }

        [TestMethod]
        public void MyClassUserEnumMockTest()
        {
            Mock<IMyClass3> mock = new Mock<IMyClass3>();
            TestEnum returnValue = TestEnum.Testing;
            mock.Implement("GetTest", returnValue);


            IMyClass3 mc = mock.Instance;
            MyClassUser3 mcu = new MyClassUser3(mc);

            TestEnum te = mcu.GetTest();
            Assert.AreEqual<TestEnum>(returnValue, te);
        }

        [TestMethod]
        public void MyClassUserStringMockTest()
        {
            // Sequence mocks supports AddExpectation and Verify
            // Implement still works but is not part of the ordered tests
            SequenceMock<IMyClass3> mock = new SequenceMock<IMyClass3>();
            IMyClass3 mc = mock.Instance;
            MyClassUser3 mcu = new MyClassUser3(mc);

            string returnValue = "N";
            mock.AddExpectation("GetInt", 1);
            mock.AddExpectation("GetString", returnValue);


            string te = mcu.GetString();
            Assert.AreEqual<string>(returnValue, te);

            // verify only for SequenceMocks
            mock.Verify();
        }

    }
}
