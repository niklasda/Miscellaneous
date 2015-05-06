using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixUser
{
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

    public class MyClassUser2
    {
        public MyClassUser2(IMyClass2 pmyClass)
        {
            myClass = pmyClass;
        }
        private IMyClass2 myClass;

        public int GetAreaSize(int[][] ints)
        {
            return myClass.GetAreaSize(ints);
        }
    }

    public class MyClassUser3
    {
        public MyClassUser3(IMyClass3 pmyClass)
        {
            myClass = pmyClass;
        }
        private IMyClass3 myClass;

        public TestEnum GetTest()
        {
            return myClass.GetTest();
        }
        public int GetInt()
        {
            return myClass.GetInt();
        }
        public string GetString()
        {
            int i = myClass.GetInt();
            return myClass.GetString();
        }
    }
}
