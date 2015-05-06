using System;

namespace MbUnitDemo
{
    public class ComparablePerson : IComparable<ComparablePerson>, IPerson
    {
        private int _age;
        private string _name;

        public ComparablePerson()
        {
        }

        public ComparablePerson(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int CompareTo(ComparablePerson other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return Int32.MaxValue;
            }
            return Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
            return id;
        }
    }
}