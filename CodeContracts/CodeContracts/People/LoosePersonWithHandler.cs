using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CodeContracts.People
{
	public class LoosePersonWithHandler
	{
	    public LoosePersonWithHandler(string name, int age)
	    {
            Contract.Requires(!string.IsNullOrEmpty(name)); // pre condition
            Contract.Requires(name != null); // -> Debug.Fail -> Environment.FailFast
            Contract.Requires(age > 0);

          //  Contract.RequiresAlways(realAge < 40);  // Always == all build configurations
                                                // Don't use privates in contracts

            Contract.Ensures(Name.Equals(name)); // post condition
            Contract.Ensures(Age == age);

            Contract.Ensures(Contract.OldValue(Age) != Age);


            Name = name;
            Age = age;
	        realAge = age - 15;
        }


	    private int realAge;
		public string Name { get; private set; }
		public int Age { get; private set; }

        public IList<string> MyStuff(IList<string> gifts)
        {
            Contract.Requires(Contract.ForAll(gifts, s => s != null));
            
            Contract.Ensures(Contract.ForAll(gifts, s => s != null));
            
            Contract.Requires(Contract.Exists(gifts, s => s != null));
            return gifts;
        }

		public override string ToString()
		{
            Contract.Assert(Name != null);

        //    Contract.Assume(Name != null); // like assert but works with static analysis
                                        // may not trigger the event??

            //Contract.Ensures(Contract.Result<string>() != null);

			string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
			return id;

		}
	}
}