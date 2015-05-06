using System;
using System.Diagnostics.Contracts;
using CodeContracts.People.Interfaces;

namespace CodeContracts.People.Contracts
{
	[ContractClassFor(typeof(IPerson))]
	sealed class IPersonContracts : IPerson
	{
		int IPerson.Age
		{
			get { throw new NotImplementedException(); }
			set { Contract.Requires(value > 0); }
		}

		string IPerson.Name
		{
			get { throw new NotImplementedException(); }
			set { Contract.Requires(value != null); }
		}

		//[ContractInvariantMethod]
		void IPerson.IsValid()
		{
			//Contract.Invariant(((IPerson)this).Age < 100);
		}

		string IPerson.ToString()
		{
			throw new NotImplementedException();
		}
	}
}