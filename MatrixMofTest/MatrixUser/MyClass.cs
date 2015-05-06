using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixUser
{
    public class MyClass : IMyClass
    {
        public int GetAreaSize(int[,] area)
        {
            int size = area.GetLength(0) * area.GetLength(1);
            return size;
        }
    }

    public class MyClass2 : IMyClass2
    {
        public int GetAreaSize(int[][] area)
        {
            int size = area.GetLength(0) * area.GetLength(1);
            return size;
        }
    }

    public class MyClass3 : IMyClass3
    {
        public TestEnum GetTest()
        {
            return TestEnum.Testing;
        }

        public int GetInt()
        {
            return 32;
        }
        public string GetString()
        {
            return "N";
        }
    }
}
