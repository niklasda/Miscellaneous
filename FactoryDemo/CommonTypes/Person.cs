using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryDemo
{
    public class Person
    {
        public Person(int pid)
        {
            id = pid;
        }
        private int id;
        public int Id
        {
            get { return id; }
        }

        private string firstName;
        private string lastName;

        public void SetName(string firstname, string lastname)
        {
            firstName = firstname;
            lastName = lastname;
        }

        public string GetName()
        {
            string name = string.Format("{0} {1}", firstName, lastName);
            return name;
        }
    }
}
