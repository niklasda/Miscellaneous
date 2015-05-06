using System;
using System.Collections.Generic;
using System.Text;

namespace VisitorDemo
{
    public sealed class Person
    {
        public string FirstName = string.Empty;
        public string LastName = string.Empty;

        // approach 1
        // the Person controls the printing

        public void PrintName(IFormUI ui)
        {
            string name = string.Format("{0} {1}", FirstName, LastName);
            ui.PrintString(name);
        }
    }
}
