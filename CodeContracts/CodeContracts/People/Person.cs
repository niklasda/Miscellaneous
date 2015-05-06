 using System.Diagnostics.Contracts;
using CodeContracts.People.Interfaces;

namespace CodeContracts.People
{
	public class Person : IPerson
	{
		public Person(string name, int age)
		{		
			Contract.Requires(name != null); // pre condition
			Contract.Requires(age > 0);
			//Contract.Requires(age < 0);

			Contract.Ensures(Name.Equals(name)); // post condition
			Contract.Ensures(Age == age);


			Name = name;
			Age = age;

		}


        [ContractInvariantMethod]
        public void IsValid()
        {
            Contract.Invariant(Age < 150);
        }		

		public string Name { get; set; }
		public int Age { get; set; }

		public override string ToString()
		{
			string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
			return id;
		}
	}
}