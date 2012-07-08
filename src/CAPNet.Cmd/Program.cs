using System;
using System.IO;
using System.Xml;

namespace CAPNet.Cmd
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

        static void ReadFromFeed(string url)
        {

        }
    }
}
