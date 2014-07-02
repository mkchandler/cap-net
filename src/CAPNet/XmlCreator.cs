using System.Linq;
using System.Xml.Linq;

using CAPNet.Models;
using System;
using System.Globalization;
using System.Collections.Generic;

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
                Validate<Status>("status", alert.Status),
                Validate<MessageType>("msgType", alert.MessageType),
                Validate<Scope>("scope", alert.Scope),
                Validate<string>("source", alert.Source),
                Validate<string>("restriction", alert.Restriction),
                Validate<string>("addresses", alert.Addresses),
                Validate<string>("code", alert.Code),
                Validate<string>("note", alert.Note),
                Validate<string>("references", alert.References),
                Validate<string>("incidents", alert.Incidents),
                alert.Info.Select(Create));

            return alertElement;
        }

        private static XElement Create(Info info)
        {
            var infoElement = new XElement(
                CAP12Namespace + "info",
                info.Categories.Select(cat => new XElement(CAP12Namespace + "category", cat)),
                new XElement(CAP12Namespace + "event", info.Event),
                Validate<string>("responseType", info.ResponseType),
                new XElement(CAP12Namespace + "urgency", info.Urgency),
                new XElement(CAP12Namespace + "severity", info.Severity),
                new XElement(CAP12Namespace + "certainty", info.Certainty),
                Validate<string>("audience", info.Audience),
                Create(info.EventCodes),
                Validate<DateTimeOffset>("effective", info.Effective),
                Validate<DateTimeOffset>("onset", info.Onset),
                Validate<DateTimeOffset>("expires", info.Expires),
                Validate<string>("senderName", info.SenderName),
                Validate<string>("headline", info.Headline),
                Validate<string>("description", info.Description),
                Validate<string>("instruction", info.Instruction),
                Validate<Uri>("web", info.Web),
                Validate<string>("contact", info.Contact),
                Create(info.Parameters),
                Create(info.Resources),
                Create(info.Areas));

            return infoElement;
        }

        private static IEnumerable<XElement> Create(IEnumerable<EventCode> codes)
        {
            IEnumerable<XElement> eventCodesElements =
                from e in codes
                select new XElement(
                    CAP12Namespace + "eventCode",
                    new XElement(CAP12Namespace + "valueName", e.ValueName),
                    new XElement(CAP12Namespace + "value", e.Value));

            return eventCodesElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<Parameter> parameters)
        {
            IEnumerable<XElement> parameterElements =
                from parameter in parameters
                select new XElement(
                    CAP12Namespace + "parameter",
                    new XElement(CAP12Namespace + "valueName", parameter.ValueName),
                    new XElement(CAP12Namespace + "value", parameter.Value));

            return parameterElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<Resource> resources)
        {
            IEnumerable<XElement> resourceElements =
            from resource in resources
            select new XElement(
                CAP12Namespace + "resource",
                new XElement(CAP12Namespace + "resourceDesc", resource.Description),
                new XElement(CAP12Namespace + "mimeType", resource.MimeType),
                Validate<int?>("size", resource.Size),
                Validate<Uri>("uri", resource.Uri),
                Validate<string>("derefUri", resource.DereferencedUri),
                Validate<string>("digest", resource.Digest));

            return resourceElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<GeoCode> geoCodes)
        {
            IEnumerable<XElement> geoCodeElements =
                from geoCode in geoCodes
                select new XElement(
                    CAP12Namespace + "geocode",
                    new XElement(CAP12Namespace + "valueName", geoCode.ValueName),
                    new XElement(CAP12Namespace + "value", geoCode.Value));

            return geoCodeElements;
        }

        private static IEnumerable<XElement> Create(IEnumerable<Area> areas)
        {
            IEnumerable<XElement> areaElements =
            from area in areas
            select new XElement(
                CAP12Namespace + "area",
                new XElement(CAP12Namespace + "areaDesc", area.Description),
                Validate<string>("altitude", area.Altitude),
                Validate<string>("ceiling", area.Ceiling),

                from polygon in area.Polygons
                select new XElement(
                    CAP12Namespace + "polygon", polygon),

                from circle in area.Circles
                select new XElement(
                    CAP12Namespace + "circle", circle),

               Create(area.GeoCodes));

            return areaElements;
        }

        private static XElement Validate<T>(string name, T content)
        {
            if (content != null)
            {
                string str = content.ToString();
                if (!content.ToString().Equals("") && !content.ToString().Equals(DateTimeOffset.MinValue.ToString()))
                    return new XElement(CAP12Namespace + name, content);
                else
                    return null;
            }
            else
                return null;
        }
    }
}