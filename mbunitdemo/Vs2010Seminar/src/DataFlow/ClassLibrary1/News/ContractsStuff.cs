using System.Diagnostics.Contracts;

namespace ClassLibrary1.News
{
    public class ContractsStuff
    {
        private int _age;

        public string MyMethod(string name, int age = 30)
        {  
            Contract.Requires(age >= 30); // pre-condition

            _age = age;
            return string.Format("Name:{0} Age:{1}", name, age);
        
            Contract.Ensures(age <= 30); // post-condition
        }

        [ContractInvariantMethod]
        public void Invarianter()
        {
            Contract.Invariant(_age <= 30); // class invariant
        }
    }
}
