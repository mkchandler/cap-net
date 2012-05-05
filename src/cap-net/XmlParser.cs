using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CAP
{
    public class XmlParser
    {
        public Alert Parse(string xml)
        {
            var document = XDocument.Parse(xml);
            var alert = ParseInternal(document);
            return alert;
        }

        private Alert ParseInternal(XDocument document)
        {
            var alert = new Alert();



            return alert;
        }
    }
}
