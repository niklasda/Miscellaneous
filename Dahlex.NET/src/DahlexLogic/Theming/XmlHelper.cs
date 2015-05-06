using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;

namespace DahlexLogic.Theming
{
    public class XmlHelper
    {
        private List<Exception> problems = new List<Exception>();

        public List<Exception> CheckIntegrity(string xmlFileName, string xslName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlFileName);

            Stream xsdStream = getEmbeddedXsd(xslName);
            XmlSchema scheme = XmlSchema.Read(xsdStream, new ValidationEventHandler(xslEventHandler));

            doc.Schemas.Add(scheme);
            doc.Validate(new ValidationEventHandler(xslEventHandler));

            return problems;
        }

        private void xslEventHandler(object sender, ValidationEventArgs e)
        {
//            XmlNamespaceManager man = (XmlNamespaceManager)sender;
            problems.Add(e.Exception);
        }

        private Stream getEmbeddedXsd(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();

            string[] resNames = a.GetManifestResourceNames();
            foreach (string resName in resNames)
            {
                if (resName.ToLower().EndsWith(name.ToLower()))
                {
                    Stream xsdStream = a.GetManifestResourceStream(resName);
                    return xsdStream;
                }
            }
            throw new ApplicationException(string.Format("Embedded XSD not found: {0}", name));
        }

        public Stream GetEmbeddedTheme(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();

            string[] resNames = a.GetManifestResourceNames();
            foreach (string resName in resNames)
            {
                if (resName.ToLower().EndsWith(name.ToLower()))
                {
                    Stream xmlStream = a.GetManifestResourceStream(resName);
                    return xmlStream;
                }
            }
            throw new ApplicationException(string.Format("Embedded Xml not found: {0}", name));
        }
    }
}
