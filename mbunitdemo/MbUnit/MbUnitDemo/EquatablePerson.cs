using System;

namespace MbUnitDemo
{
    public class EquatablePerson : IEquatable<EquatablePerson>, IPerson
    {
        private int _age;
        private string _name;

        public EquatablePerson()
        {}

        public EquatablePerson(string name, int age)
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


        public bool Equals(EquatablePerson other)
        {

            if (object.ReferenceEquals(other, null))
                return false;
            
            return Age == other.Age;
        }

        public override bool Equals(object other)
        {
            return Equals(other as EquatablePerson);
        }

        public override int GetHashCode()
        {
            return Age.GetHashCode();
        }

        public override string ToString()
        {
            string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
            return id;
        }
    }
}