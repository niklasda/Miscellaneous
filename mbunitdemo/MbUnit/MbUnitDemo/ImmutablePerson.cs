using System;
using System.Runtime.Serialization;

namespace MbUnitDemo
{
    [Serializable]
    public class ImmutablePerson
    {
        private readonly int _age;
        private readonly string _name;

        public ImmutablePerson()
        {    
        }

        public ImmutablePerson(string name, int age)
        {		
            _name = name;
            _age = age;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Age
        {
            get { return _age; }
        }

        public override string ToString()
        {
            string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
            return id;
        }
    }
}