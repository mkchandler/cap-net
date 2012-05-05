using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CAP.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = null;

            var document = new XmlDocument();
            try
            {
                document.Load(@"c:\_dev\cap-net\test\nws-warning.xml");
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }

            using (StringWriter sringWriter = new StringWriter())
            {
                using (XmlTextWriter textWriter = new XmlTextWriter(sringWriter))
                {
                    document.WriteTo(textWriter);
                    xml = sringWriter.ToString();
                }
            }

            if (xml != null)
            {
                var alert = XmlParser.Parse(xml);
            }
        }
    }
}
