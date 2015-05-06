using MbUnit.Framework;

namespace MbUnitDemo.Tests.Extensions
{
    public static class Categories
    {
        public const string Assertions = "Assertions";
        public const string Attributes = "Attributes";
        public const string DataDriven = "DataDriven";
        public const string Factories = "Factories";
        public const string Joins = "Joins";
        public const string Logs = "Logs";
        public const string Ordering = "Ordering";
        public const string Parameterized = "Parameterized";
        public const string Persistence = "Persistence";
        public const string Verifiers = "Verifiers";
        public const string Watin = "Watin";
    }


    public class AssertionsCategoryAttribute : CategoryAttribute
    {
        public AssertionsCategoryAttribute()
            : base(Categories.Assertions)
        {
        }
    }
}