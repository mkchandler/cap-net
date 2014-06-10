using System.Xml.Linq;

namespace CAPNet
{
    public static class XmlCreator
    {
        public static XNamespace CAP12Namespace = "urn:oasis:names:tc:emergency:cap:1.2";

        public static XElement Create(Alert alert)
        {
            return new XElement(
                CAP12Namespace + "alert",
                new XElement(CAP12Namespace + "sender", alert.Sender));
        }
    }
}