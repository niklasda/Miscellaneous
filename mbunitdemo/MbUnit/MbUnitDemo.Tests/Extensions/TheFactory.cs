using System;
using System.Collections.Generic;
using Gallio.Framework.Data;
using MbUnitDemo.Exception;

namespace MbUnitDemo.Tests.Extensions
{
    public class TheFactory
    {
        public static IEnumerable<Type> TypeGen()
        {
            yield return typeof(Person);
            yield return typeof(EquatablePerson);
            yield return typeof(ComparablePerson);
        }

        public static IEnumerable<string> NameGen()
        {
            yield return "Nils";
            yield return "Niklas";
        }

        public static IEnumerable<int> AgeGen()
        {
            yield return 10;
            yield return 100;
        }

        public static IEnumerable<Type> ExceptionGen()
        {
            yield return typeof(AgeException);
            yield return typeof(NullReferenceException);
        }
    }
}