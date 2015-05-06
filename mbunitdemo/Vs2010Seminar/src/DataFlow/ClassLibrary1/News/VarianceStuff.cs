using System;
using System.Collections.Generic;

namespace ClassLibrary1.News
{
    public class VarianceStuff
    {
        public void CovariantMethod()
        {
            string aString = new String('x', 3);
            object anObject = new Object();

            anObject = aString;
        }

        public void CovariantContainerMethod()
        {
            // public interface IEnumerable<out T>;
            // return type is covariant

            IEnumerable<string> strings = new List<string>();
            IEnumerable<object> objects = new List<object>();

            objects = strings;
        }

        public void NonCovariantContainerMethod()
        {
            // public interface IList<T>;
            // IList uses T as both in and out type, i.e. nonvariant

            IList<string> strings = new List<string>();
            IList<object> objects = new List<object>();

            // runtime error: invalid cast
            objects = (IList<object>)strings;
        }

        public void ContraVariantMethod()
        {
            // public interface IComparable<in T>
            // argument type is contravariant

            IComparer<object> objComp = new ObjectComparer();
            IComparer<string> stringComp = new MyStringComparer();

            stringComp = objComp;
        }
    }


    // in i contravariant
    public interface ICoStuff<in T>
    {
        int Compare(T one, T two);
    }

    // out is covariant
    public interface ICoOutStuff<out T>
    {
        T Do(int one, int two);
    }

    public class ObjectComparer : IComparer<object>
    {
        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }

    public class MyStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            throw new NotImplementedException();
        }
    }
}
