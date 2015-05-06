using System.Diagnostics.Contracts;
using CodeContracts.People.Exceptions;

namespace CodeContracts.People
{
	public class ThrowingPerson
	{
		public ThrowingPerson(string name, int age)
		{
            Contract.EnsuresOnThrow<AgeException>(Name != "StålFarfar");

			Name = name;
			Age = age;

		}

		public string Name { get; private set; }
	    private int age;

	    public int Age
	    {
	        get { return age; }
	        private set
	        {
	            if(value>=200 && Name != "StålFarfar")
	                throw new AgeException();
                age = value;
	        } 
	    }

	    public override string ToString()
		{
			string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
			return id;
		}
	}
}