using System.Xml.Linq;

namespace CAPNet
{
    /// <summary>
    /// Class that converts an alert to its XML representation
    /// </summary>
    public static class XmlCreator
    {
        /// <summary>
        /// The xml namespace for CAP 1.2
        /// </summary>
        public static readonly XNamespace CAP12Namespace = "urn:oasis:names:tc:emergency:cap:1.2";

        /// <summary>
        /// Build a XML element representing the alert
        /// </summary>
        /// <param name="alert">The alert</param>
        /// <returns>An XML representation of the alert</returns>
        public static XElement Create(Alert alert)
        {
            return new XElement(
                CAP12Namespace + "alert",
                new XElement(CAP12Namespace + "identifier", alert.Identifier),
                new XElement(CAP12Namespace + "sender", alert.Sender),
                // set milliseconds to 0
                new XElement(CAP12Namespace + "sent", alert.Sent.AddMilliseconds(-alert.Sent.Millisecond)),
                new XElement(CAP12Namespace + "status", alert.Status),
                new XElement(CAP12Namespace + "msgType", alert.MessageType),
                new XElement(CAP12Namespace + "scope", alert.Scope));
        }
    }
}