using System;
using ProxyMocker.Constraints;

namespace ProxyMocker
{
	/// <summary>
	/// Description of ExpectationAction.
	/// </summary>
	public class ExpectationAction : IExpectationAction
	{
		public ExpectationAction(IExpectation parentExpectation)
		{
			expectation = parentExpectation;
		}
		
		private IExpectation expectation;
        private IConstraint[] argumentContraints;
        private object[] outAndRefParameters;
		
		public IExpectationAction WithArgumentConstraints(params IConstraint[] args)
		{
            if (args.Length != expectation.GetArgumentsCount())
            {
                throw new ExpectationException(string.Format("The number of argument constraints does not match the number of argument in {0}",expectation.GetMethodName()));
            };
            argumentContraints = args;
			return this;
		}
		
		public IExpectationAction SetOutAndRefParametersTo(params object[] args)
		{
            outAndRefParameters = args;
            return this;
		}


        public IConstraint GetConstraint(int j)
        {
            return argumentContraints[j];
        }
    }
}
