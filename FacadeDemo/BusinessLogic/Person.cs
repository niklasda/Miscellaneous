using System;
using System.Collections.Generic;
using System.Text;

namespace FacadeDemo
{
    public class Person
    {
        public Person(string theName)
        {
            name = theName;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
