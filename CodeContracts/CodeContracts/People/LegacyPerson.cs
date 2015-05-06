using System;
using System.Diagnostics.Contracts;

namespace CodeContracts.People
{
	public class LegacyPerson
	{
		public LegacyPerson(string name, int age)
		{
            if(name == null)
                throw new ArgumentNullException("name");

			Contract.EndContractBlock();


			Name = name;
			Age = age;

		}

		public string Name { get; private set; }
		public int Age { get; private set; }

		public override string ToString()
		{

			string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
			return id;
		}
	}
}