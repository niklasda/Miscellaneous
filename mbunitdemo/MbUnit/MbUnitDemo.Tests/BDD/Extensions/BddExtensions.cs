using MbUnit.Framework;
using NBehave.Spec.MbUnit;

namespace MbUnitDemo.Tests.BDD.Extensions
{
    using Describe = TestsOnAttribute;
    using InContext = DescriptionAttribute;
    using It = TestAttribute;
    using Should = DescriptionAttribute;
    using By = AuthorAttribute;
    using Tag = CategoryAttribute;

    // amplify, amptools

    [
		Author("Niklas Dahlman", "nd@sql8r.net", "nida.se"),
		Describe("Person Specification"),
		InContext("Basic Person usage")
	]
	public class PersonObject : SpecBase
	{

		[It, Should("Be possible to create an uninitialized Person")]
		public void CreateAnUninitializedPerson()
		{       
            var p = new Person();

            p.ShouldNotBeNull();
		    p.Name.ShouldBeNull();
            p.Age.ShouldEqual(0);
		}
	}
}
