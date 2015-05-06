using System;

namespace ObserverDemo
{
    /// <summary>
    /// The person class can be observed using eventhandlers
    /// </summary>
    public class Person
    {
        public Person(string theName)
        {
            name = theName;

            PersonChanger changer = new PersonChanger(this);
        }

        private string name;
        public string Name
        {
            get { return name;  }
            set
            {
                name = value;
                if (OnNameChanged != null)
                {
                    OnNameChanged(name);
                }
            }
        }

        public event PersonEventHandler OnNameChanged;
    }
}
