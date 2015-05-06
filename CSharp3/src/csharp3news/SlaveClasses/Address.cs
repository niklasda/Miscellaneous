using System;

namespace LinqDemo
{
    public class Address
    {
        private string street;
        private string city;

        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
     }
}