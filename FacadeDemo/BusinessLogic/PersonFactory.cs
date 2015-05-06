using System;
using System.Xml;

namespace FacadeDemo
{
    public class PersonFactory
    {
        public Person CreatePersonFromXml(XmlTextReader xtr)
        {
            string result = string.Empty;
            while (xtr.Read())
            {
                if (xtr.Name.Equals("Person") && xtr.HasAttributes)
                {
                    result = xtr.GetAttribute("name");
                }
            }

            xtr.Close();
            return new Person(result);
        }

        public Person CreatePersonFromXmlFacade(IXmlReaderFacade xrf)
        {
            string result = string.Empty;

            string name = xrf.GetPersonName();
                

            return new Person(name);
        }
    }
}
