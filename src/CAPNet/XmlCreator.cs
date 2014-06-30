using System.Linq;
using System.Xml.Linq;

using CAPNet.Models;

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
            var alertElement = new XElement(
                CAP12Namespace + "alert",
                new XElement(CAP12Namespace + "identifier", alert.Identifier),
                new XElement(CAP12Namespace + "sender", alert.Sender),
                // set milliseconds to 0
                new XElement(CAP12Namespace + "sent", alert.Sent.AddMilliseconds(-alert.Sent.Millisecond)),
                new XElement(CAP12Namespace + "status", alert.Status),
                new XElement(CAP12Namespace + "msgType", alert.MessageType),
                new XElement(CAP12Namespace + "scope", alert.Scope),
                new XElement(CAP12Namespace + "source", alert.Source),
                new XElement(CAP12Namespace + "restriction", alert.Restriction),
                new XElement(CAP12Namespace + "addresses", alert.Addresses),
                new XElement(CAP12Namespace + "code", alert.Code),
                new XElement(CAP12Namespace + "note", alert.Note),
                new XElement(CAP12Namespace + "references", alert.References),
                new XElement(CAP12Namespace + "incidents", alert.Incidents),
                alert.Info.Select(Create));

            return alertElement;
        }

        private static XElement Create(Info info)
        {
            var infoElement = new XElement(
                CAP12Namespace + "info",
                info.Categories.Select(cat => new XElement(CAP12Namespace + "category", cat)),
                new XElement(CAP12Namespace + "event", info.Event),
                new XElement(CAP12Namespace + "responseType", info.ResponseType),
                new XElement(CAP12Namespace + "urgency", info.Urgency),
                new XElement(CAP12Namespace + "severity", info.Severity),
                new XElement(CAP12Namespace + "certainty", info.Certainty),
                new XElement(CAP12Namespace + "audience", info.Audience),
                from e in info.EventCodes
                select new XElement(
                    CAP12Namespace + "eventCode",
                    new XElement(CAP12Namespace + "valueName", e.ValueName),
                    new XElement(CAP12Namespace + "value", e.Value)),
                new XElement(CAP12Namespace + "effective", info.Effective),
                new XElement(CAP12Namespace + "onset", info.Onset),
                new XElement(CAP12Namespace + "expires", info.Expires),
                new XElement(CAP12Namespace + "senderName", info.SenderName),
                new XElement(CAP12Namespace + "headline", info.Headline),
                new XElement(CAP12Namespace + "description", info.Description),
                new XElement(CAP12Namespace + "instruction", info.Instruction),
                new XElement(CAP12Namespace + "web", info.Web),
                new XElement(CAP12Namespace + "contact", info.Contact),
                from p in info.Parameters
                select new XElement(
                    CAP12Namespace + "parameter",
                    new XElement(CAP12Namespace + "valueName", p.ValueName),
                    new XElement(CAP12Namespace + "value", p.Value)),
                from r in info.Resources
                select new XElement(
                    CAP12Namespace + "resource",
                    new XElement(CAP12Namespace + "resourceDesc", r.Description),
                    new XElement(CAP12Namespace + "mimeType", r.MimeType),
                    new XElement(CAP12Namespace + "uri", r.Uri)),
                from a in info.Areas
                select new XElement(
                    CAP12Namespace + "area",
                    new XElement(CAP12Namespace + "areaDesc", a.Description),
                    new XElement(CAP12Namespace + "altitude", a.Altitude),
                    new XElement(CAP12Namespace + "ceiling", a.Ceiling),
                    from geo in a.GeoCodes
                    select new XElement(
                        CAP12Namespace + "geocode",
                        new XElement(CAP12Namespace + "valueName", geo.ValueName),
                        new XElement(CAP12Namespace + "value", geo.Value))
                ));

            return infoElement;
        }
    }
}