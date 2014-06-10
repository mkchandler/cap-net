using System.Xml.Linq;

namespace CAPNet.Tests
{
    public static class XmlCreator
    {
        private static XNamespace CAP12Namespace = "urn:oasis:names:tc:emergency:cap:1.2";

        public static XElement Create(Alert alert)
        {
            return new XElement(CAP12Namespace + "alert");
        }
    }
}