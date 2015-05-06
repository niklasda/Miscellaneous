
namespace ProxyMocker
{
    public enum ExpectationType { 
		/// <summary>calls must be used in the same order as they are expected
		/// and the same number of times</summary>
		OrderedCounted, 
		/// <summary>calls must be used in the same order as they are expected
		/// not counted</summary>
		OrderedUncounted, 
		///<summary>calls must be used the same number of times as they are expected.
		/// not necessarily in order</summary>
		UnOrderedCounted, 
		/// <summary>calls must be expected before use. 
		/// but not in order and not counted</summary>
		UnOrderedUnOrdered };

    public enum UsingType { 
		///<summary>All calls must be expected, no more no less</summary>
		Strict, 
		///<summary>Expectations are validated, but unexpected calls are ok</summary>
		Dynamic,
		///<summary>Nothing needs to be expected.</summary>
		Loose };
	
    ///<summary>the internal state of the generator</summary>
    public enum MockerMode { Expecting, Using, None };
    
 
    /// obsolete. replaced by unique method names
    /// </summary>
 //   public enum ExpType { Expect, ExpectAndReturn, ExpectAndCall, ExpectAndThrow,
   //     ExpectAndSameReturn
   // };
    
}
