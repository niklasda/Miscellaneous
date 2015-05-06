using System;
using System.Collections.Generic;
using System.Xml;

namespace FacadeDemo
{
    public class XmlReaderFacade : IXmlReaderFacade
    {
        public XmlReaderFacade(string filename)
        {
            xtr = new XmlTextReader(filename);
        }
        XmlTextReader xtr;

        public string GetPersonName()
        {
            string result = string.Empty;
            while (xtr.Read())
            {
                if (xtr.Name.Equals("Person") && xtr.HasAttributes)
                {
                    result = xtr.GetAttribute("name");
                }
            }
            return result;
        }
    }
}
