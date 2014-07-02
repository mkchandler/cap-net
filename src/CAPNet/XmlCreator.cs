using System.Linq;
using System.Xml.Linq;

using CAPNet.Models;
using System;
using System.Globalization;

namespace CAPNet
{
    /// <summary>
    /// Class that converts an alert to its XML representation
    /// </summary>
    public static class XmlCreator
    {
        /// <summary>
        /// The xml namespace for CAP 1.1
        /// </summary>
        public static readonly XNamespace CAP11Namespace = "urn:oasis:names:tc:emergency:cap:1.1";

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
                new XElement(CAP12Namespace + "source", alert.Source).validateElement(),
                new XElement(CAP12Namespace + "restriction", alert.Restriction).validateElement(),
                new XElement(CAP12Namespace + "addresses", alert.Addresses).validateElement(),
                new XElement(CAP12Namespace + "code", alert.Code).validateElement(),
                new XElement(CAP12Namespace + "note", alert.Note).validateElement(),
                new XElement(CAP12Namespace + "references", alert.References).validateElement(),
                new XElement(CAP12Namespace + "incidents", alert.Incidents).validateElement(),
                alert.Info.Select(Create));

            return alertElement;
        }

        private static XElement Create(Info info)
        {
            var infoElement = new XElement(
                CAP12Namespace + "info",
                info.Categories.Select(cat => new XElement(CAP12Namespace + "category", cat)),
                new XElement(CAP12Namespace + "event", info.Event),
                new XElement(CAP12Namespace + "responseType", info.ResponseType).validateElement(),
                new XElement(CAP12Namespace + "urgency", info.Urgency),
                new XElement(CAP12Namespace + "severity", info.Severity),
                new XElement(CAP12Namespace + "certainty", info.Certainty),
                new XElement(CAP12Namespace + "audience", info.Audience).validateElement(),

                (info.EventCodes != null) ?
                    from e in info.EventCodes
                    select new XElement(
                        CAP12Namespace + "eventCode",
                        new XElement(CAP12Namespace + "valueName", e.ValueName),
                        new XElement(CAP12Namespace + "value", e.Value))
                : null,

                new XElement(CAP12Namespace + "effective", info.Effective).validateElement(),
                new XElement(CAP12Namespace + "onset", info.Onset).validateElement(),
                new XElement(CAP12Namespace + "expires", info.Expires).validateElement(),
                new XElement(CAP12Namespace + "senderName", info.SenderName).validateElement(),
                new XElement(CAP12Namespace + "headline", info.Headline).validateElement(),
                new XElement(CAP12Namespace + "description", info.Description).validateElement(),
                new XElement(CAP12Namespace + "instruction", info.Instruction).validateElement(),
                new XElement(CAP12Namespace + "web", info.Web).validateElement(),
                new XElement(CAP12Namespace + "contact", info.Contact).validateElement(),

                (info.Parameters != null) ? 
                    from p in info.Parameters
                    select new XElement(
                        CAP12Namespace + "parameter",
                        new XElement(CAP12Namespace + "valueName", p.ValueName),
                        new XElement(CAP12Namespace + "value", p.Value))
                :null,

                (info.Resources != null) ?
                    from r in info.Resources
                    select new XElement(
                        CAP12Namespace + "resource",
                        new XElement(CAP12Namespace + "resourceDesc", r.Description),
                        new XElement(CAP12Namespace + "mimeType", r.MimeType),
                        new XElement(CAP12Namespace + "size", r.Size).validateElement(),
                        new XElement(CAP12Namespace + "uri", r.Uri).validateElement(),
                        new XElement(CAP12Namespace + "derefUri", r.DereferencedUri).validateElement(),
                        new XElement(CAP12Namespace + "digest", r.Digest).validateElement())
                :null,

                (info.Areas !=null) ?
                from area in info.Areas
                select new XElement(
                    CAP12Namespace + "area",
                    new XElement(CAP12Namespace + "areaDesc", area.Description).validateElement(),
                    new XElement(CAP12Namespace + "altitude", area.Altitude).validateElement(),
                    new XElement(CAP12Namespace + "ceiling", area.Ceiling).validateElement(),

                    (area.Polygons != null) ?
                        from polygon in area.Polygons
                        select new XElement(
                            CAP12Namespace+"polygon", polygon)
                    :null,

                    (area.Circles != null) ?
                    from circle in area.Circles
                        select new XElement(
                            CAP12Namespace + "circle", circle)
                    :null,

                    (area.GeoCodes != null) ?
                    from geo in area.GeoCodes
                        select new XElement(
                            CAP12Namespace + "geocode",
                            new XElement(CAP12Namespace + "valueName", geo.ValueName),
                            new XElement(CAP12Namespace + "value", geo.Value))
                    :null
                )
                :null);

            return infoElement;
        }

        private static XElement validateElement(this XElement element)
        {
            
            if (element.Value != "")
                return element;
            else
                return null;
        }
    }
}