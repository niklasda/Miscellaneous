using System;

namespace LinqDemo
{
    public class Person
    {
        private string name;
        private string gender;
        public int Age;
        public Address Adr;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Gender
        {
            set { gender = value; }
        }
        
        public string NormalizeName()
        {
            return name.Normalize();
        }
        
        public void DoAlmostNothing()
        {
            Console.WriteLine("Doing nothing...");
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} ", name, gender, Age, Adr.Street, Adr.City);
        }
    }
}