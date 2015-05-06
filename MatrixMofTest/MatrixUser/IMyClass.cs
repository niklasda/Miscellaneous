using System;
namespace MatrixUser
{
    public enum TestEnum { Testing, One, Two, Three };
    public interface IMyClass
    {
        int GetAreaSize(int[,] area);
    }

    public interface IMyClass2
    {
        int GetAreaSize(int[][] area);
    }

    public interface IMyClass3
    {
        TestEnum GetTest();
        string GetString();
        int GetInt();
    }


}
