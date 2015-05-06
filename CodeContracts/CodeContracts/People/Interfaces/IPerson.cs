using System.Diagnostics.Contracts;
using CodeContracts.People.Contracts;

namespace CodeContracts.People.Interfaces
{
	[ContractClass(typeof(IPersonContracts))]
	public interface IPerson
	{
		int Age { get; set; }
		string Name { get; set; }
		string ToString();

	    [ContractInvariantMethod]
	    void IsValid();
	}
}