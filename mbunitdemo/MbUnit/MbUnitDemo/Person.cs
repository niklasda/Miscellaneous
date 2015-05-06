using System;
using MbUnitDemo.Exception;

namespace MbUnitDemo
{
    public class Person : IPerson
    {
        private int _age;
        private string _name;

        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name");
    
                _name = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0) 
                    throw new AgeException("Age cannot be less than 0");
                
                _age = value;
            }
        }

        public override string ToString()
        {
            string id = string.Format("{0} - {1} - {2}", GetType(), Name, Age);
            return id;
        }

        private int getAge()
        {
            return _age;
        }
    }
}