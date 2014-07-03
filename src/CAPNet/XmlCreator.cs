using System.Linq;
using System.Xml.Linq;

using CAPNet.Models;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;

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
        /// 
        /// </summary>
        /// <param name="alerts"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> Create(IEnumerable<Alert> alerts)
        {
            return from alert in alerts
                   select Create(alert);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="alert"></param>
        /// <returns></returns>
        public static XElement Create(Alert alert)
        {
            var alertElement = new XElement(
                CAP12Namespace + "alert",
                new XElement(CAP12Namespace + "identifier", alert.Identifier),
                new XElement(CAP12Namespace + "sender", alert.Sender),
                // set milliseconds to 0
                new XElement(CAP12Namespace + "sent", alert.Sent.AddMilliseconds(-alert.Sent.Millisecond)),
                AddElementIfHasContent("status", alert.Status),
                AddElementIfHasContent("msgType", alert.MessageType),
                AddElementIfHasContent("scope", alert.Scope),
                AddElementIfHasContent("source", alert.Source),
                AddElementIfHasContent("restriction", alert.Restriction),
                AddElementIfHasContent("addresses", alert.Addresses),
                AddElementIfHasContent("code", alert.Code),
                AddElementIfHasContent("note", alert.Note),
                AddElementIfHasContent("references", alert.References),
                AddElementIfHasContent("incidents", alert.Incidents),
                alert.Info.Select(Create));

            return alertElement;
        }

        private static XElement Create(Info info)
        {
            var infoElement = new XElement(
                CAP12Namespace + "info",
                info.Categories.Select(cat => new XElement(CAP12Namespace + "category", cat)),
                new XElement(CAP12Namespace + "event", info.Event),
                AddElementIfHasContent("responseType", info.ResponseType),
                new XElement(CAP12Namespace + "urgency", info.Urgency),
                new XElement(CAP12Namespace + "severity", info.Severity),
                new XElement(CAP12Namespace + "certainty", info.Certainty),
                AddElementIfHasContent("audience", info.Audience),
                Create(info.EventCodes),
                AddElementIfHasContent("effective", info.Effective),
                AddElementIfHasContent("onset", info.Onset),
                AddElementIfHasContent("expires", info.Expires),
                AddElementIfHasContent("senderName", info.SenderName),
                AddElementIfHasContent("headline", info.Headline),
                AddElementIfHasContent("description", info.Description),
                AddElementIfHasContent("instruction", info.Instruction),
                AddElementIfHasContent("web", info.Web),
                AddElementIfHasContent("contact", info.Contact),
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
                    AddElementIfHasContent("mimeType", resource.MimeType),
                    AddElementIfHasContent("size", resource.Size),
                    AddElementIfHasContent("uri", resource.Uri),
                    AddElementIfHasContent("derefUri", resource.DereferencedUri),
                    AddElementIfHasContent("digest", resource.Digest));

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
                    AddElementIfHasContent("altitude", area.Altitude),
                    AddElementIfHasContent("ceiling", area.Ceiling),

                    from polygon in area.Polygons
                    select new XElement(
                        CAP12Namespace + "polygon", polygon),

                    from circle in area.Circles
                    select new XElement(
                        CAP12Namespace + "circle", circle),

                   Create(area.GeoCodes));

            return areaElements;
        }

        private static XElement AddElementIfHasContent<T>(string name, T content)
        {
            if (content != null)
                if (!content.ToString().Equals("") && !content.ToString().Equals(DateTimeOffset.MinValue.ToString()))
                    return new XElement(CAP12Namespace + name, content);

            return null;
        }
    }
}