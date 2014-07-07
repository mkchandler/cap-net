using CAPNet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IEnumerable<Alert> Parse(string xml)
        {
            var document = XDocument.Parse(xml);
            var alertList = ParseInternal(document);

            return alertList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static IEnumerable<Alert> Parse(XDocument xml)
        {
            var alertList = ParseInternal(xml);

            return alertList;
        }

        private static IEnumerable<Alert> ParseInternal(XDocument xdoc)
        {
            var elements = xdoc.Descendants(XmlCreator.CAP12Namespace + "alert");
            if (!elements.Any())
            {
                elements = xdoc.Descendants(XmlCreator.CAP11Namespace + "alert");
            }

            return from alertElement in elements
                   select ParseAlert(alertElement);
        }

        private static Alert ParseAlert(XElement alertElement)
        {
            Alert alert = new Alert();

            var capNamespace = alertElement.Name.Namespace;

            var infoNode = alertElement.Element(capNamespace + "info");
            if (infoNode != null)
            {
                var info = ParseInfo(infoNode);
                alert.Info.Add(info);
            }

            var incidentsNode = alertElement.Element(capNamespace + "incidents");
            if (incidentsNode != null)
            {
                alert.Incidents = incidentsNode.Value;
            }

            var referencesNode = alertElement.Element(capNamespace + "references");
            if (referencesNode != null)
            {
                alert.References = referencesNode.Value;
            }

            var noteNode = alertElement.Element(capNamespace + "note");
            if (noteNode != null)
            {
                alert.Note = noteNode.Value;
            }

            var codeNode = alertElement.Element(capNamespace + "code");
            if (codeNode != null)
            {
                alert.Code = codeNode.Value;
            }

            var addressesNode = alertElement.Element(capNamespace + "addresses");
            if (addressesNode != null)
            {
                alert.Addresses = addressesNode.Value;
            }

            var restrictionNode = alertElement.Element(capNamespace + "restriction");
            if (restrictionNode != null)
            {
                alert.Restriction = restrictionNode.Value;
            }

            var scopeNode = alertElement.Element(capNamespace + "scope");
            if (scopeNode != null)
            {
                alert.Scope = (Scope)Enum.Parse(typeof(Scope), scopeNode.Value, true);
            }

            var sourceNode = alertElement.Element(capNamespace + "source");
            if (sourceNode != null)
            {
                alert.Source = sourceNode.Value;
            }

            var msgTypeNode = alertElement.Element(capNamespace + "msgType");
            if (msgTypeNode != null)
            {
                alert.MessageType = (MessageType)Enum.Parse(typeof(MessageType), msgTypeNode.Value, true);
            }

            var statusNode = alertElement.Element(capNamespace + "status");
            if (statusNode != null)
            {
                alert.Status = (Status)Enum.Parse(typeof(Status), statusNode.Value, true);
            }

            var sentNode = alertElement.Element(capNamespace + "sent");
            if (sentNode != null)
            {
                alert.Sent = DateTimeOffset.Parse(sentNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNode = alertElement.Element(capNamespace + "sender");
            if (senderNode != null)
            {
                alert.Sender = senderNode.Value;
            }

            var identifierNode = alertElement.Element(capNamespace + "identifier");
            if (identifierNode != null)
            {
                alert.Identifier = identifierNode.Value;
            }

            return alert;
        }

        private static Info ParseInfo(XElement infoElement)
        {
            var info = new Info();

            var capNamespace = infoElement.Name.Namespace;

            var languageNode = infoElement.Element(capNamespace + "language");
            if (languageNode != null)
                info.Language = languageNode.Value;

            var categoryQuery = from categoryNode in infoElement.Elements(capNamespace + "category")
                                where categoryNode != null
                                select (Category)Enum.Parse(typeof(Category), categoryNode.Value, true);

            foreach (var category in categoryQuery)
            {
                info.Categories.Add(category);
            }

            var eventNode = infoElement.Element(capNamespace + "event");
            if (eventNode != null)
            {
                info.Event = eventNode.Value;
            }

            var responseTypeQuery = from responseTypeNode in infoElement.Elements(capNamespace + "responseType")
                                    where responseTypeNode != null
                                    select (ResponseType)Enum.Parse(typeof(ResponseType), responseTypeNode.Value,true);

            foreach (var responseType in responseTypeQuery)
            {
                info.ResponseTypes.Add(responseType);
            }

            var urgencyNode = infoElement.Element(capNamespace + "urgency");
            if (urgencyNode != null)
            {
                info.Urgency = (Urgency)Enum.Parse(typeof(Urgency), urgencyNode.Value, true);
            }

            var certaintyNode = infoElement.Element(capNamespace + "certainty");
            if (certaintyNode != null)
            {
                if (certaintyNode.Value == "Very Likely")
                {
                    info.Certainty = Certainty.Likely;
                }
                else
                {
                    info.Certainty = (Certainty)Enum.Parse(typeof(Certainty), certaintyNode.Value, true);
                }
            }

            var audienceNode = infoElement.Element(capNamespace + "audience");
            if (audienceNode != null)
            {
                info.Audience = audienceNode.Value;
            }

            IEnumerable<XElement> eventCodesQuerry =
                from ev in infoElement.Elements(capNamespace + "eventCode")
                where ev != null
                select ev;

            foreach (XElement eventCode in eventCodesQuerry)
            {
                string valueName = eventCode.Element(capNamespace + "valueName").Value;
                string value = eventCode.Element(capNamespace + "value").Value; ;
                info.EventCodes.Add(new EventCode(valueName, value));
            }

            var effectiveNode = infoElement.Element(capNamespace + "effective");
            if (effectiveNode != null)
            {
                info.Effective = DateTimeOffset.Parse(effectiveNode.Value, CultureInfo.InvariantCulture);
            }

            var severityNode = infoElement.Element(capNamespace + "severity");
            if (severityNode != null)
            {
                info.Severity = (Severity)Enum.Parse(typeof(Severity), severityNode.Value, true);
            }

            var onsetNode = infoElement.Element(capNamespace + "onset");
            if (onsetNode != null)
            {
                info.Onset = DateTimeOffset.Parse(onsetNode.Value, CultureInfo.InvariantCulture);
            }

            var expiresNode = infoElement.Element(capNamespace + "expires");
            if (expiresNode != null)
            {
                info.Expires = DateTimeOffset.Parse(expiresNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNameNode = infoElement.Element(capNamespace + "senderName");
            if (senderNameNode != null)
            {
                info.SenderName = senderNameNode.Value;
            }

            var headlineNode = infoElement.Element(capNamespace + "headline");
            if (headlineNode != null)
            {
                info.Headline = headlineNode.Value;
            }

            var descriptionNode = infoElement.Element(capNamespace + "description");
            if (descriptionNode != null)
            {
                info.Description = descriptionNode.Value;
            }

            var instructionNode = infoElement.Element(capNamespace + "instruction");
            if (instructionNode != null)
            {
                info.Instruction = instructionNode.Value;
            }

            var webNode = infoElement.Element(capNamespace + "web");
            if (webNode != null)
            {
                info.Web = new Uri(webNode.Value);
            }

            var contactNode = infoElement.Element(capNamespace + "contact");
            if (contactNode != null)
            {
                info.Contact = contactNode.Value;
            }

            var parameterQuery = from parameter in infoElement.Elements(capNamespace + "parameter")
                                 let valueNameNode = parameter.Element(capNamespace + "valueName")
                                 let valueNode = parameter.Element(capNamespace + "value")
                                 where valueNameNode != null && valueNode != null
                                 select new Parameter(valueNameNode.Value, valueNode.Value);

            foreach (var parameter in parameterQuery)
            {
                info.Parameters.Add(parameter);
            }

            var resourceQuery = from resourceNode in infoElement.Elements(capNamespace + "resource")
                                where resourceNode != null
                                select ParseResource(resourceNode);

            foreach (var resource in resourceQuery)
            {
                info.Resources.Add(resource);
            }

            var areaQuery = from areaNode in infoElement.Elements(capNamespace + "area")
                            where areaNode != null
                            select ParseArea(areaNode);

            foreach (var area in areaQuery)
            {
                info.Areas.Add(area);
            }

            return info;
        }

        private static Area ParseArea(XElement areaElement)
        {
            var area = new Area();

            var capNamespace = areaElement.Name.Namespace;

            var areaDescNode = areaElement.Element(capNamespace + "areaDesc");
            if (areaDescNode != null)
                area.Description = areaDescNode.Value;

            var polygonQuery = from polygonNode in areaElement.Elements(capNamespace + "polygon")
                               where polygonNode != null
                               select polygonNode.Value;

            foreach (var polygonValue in polygonQuery)
                area.Polygons.Add(new Polygon(polygonValue));

            var circleQuery = from circleNode in areaElement.Elements(capNamespace + "circle")
                              where circleNode != null
                              select circleNode.Value;

            foreach (var circleValue in circleQuery)
                area.Circles.Add(new Circle(circleValue));

            var geoCodeQuery = from geoCodeNode in areaElement.Elements(capNamespace + "geocode")
                               where geoCodeNode != null
                               select geoCodeNode;

            var altitudeNode = areaElement.Element(capNamespace + "altitude");
            if (altitudeNode != null)
                area.Altitude = int.Parse(altitudeNode.Value);

            var ceilingNode = areaElement.Element(capNamespace + "ceiling");
            if (ceilingNode != null)
                area.Ceiling = int.Parse(ceilingNode.Value);

            foreach (XElement geoCodeValue in geoCodeQuery)
            {
                string valueName = geoCodeValue.Element(capNamespace + "valueName").Value;
                string value = geoCodeValue.Element(capNamespace + "value").Value;

                area.GeoCodes.Add(new GeoCode(valueName, value));
            }
            return area;
        }

        private static Resource ParseResource(XElement resourceElement)
        {
            var resource = new Resource();

            var capNamespace = resourceElement.Name.Namespace;

            //<resource>
            //    <resourceDesc>Image file (GIF)</resourceDesc>
            //    <mimeType>image/gif</mimeType>
            //    <size>1</size>
            //    <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            //    <derefUri>derefUri</derefUri>
            //    <digest>digest</digest>
            //</resource>

            var resourceDescNode = resourceElement.Element(capNamespace + "resourceDesc");
            if (resourceDescNode != null)
                resource.Description = resourceDescNode.Value;

            var mimeTypeNode = resourceElement.Element(capNamespace + "mimeType");
            if (mimeTypeNode != null)
                resource.MimeType = mimeTypeNode.Value;

            var sizeNode = resourceElement.Element(capNamespace + "size");
            if (sizeNode != null)
                resource.Size = int.Parse(sizeNode.Value);

            var uriNode = resourceElement.Element(capNamespace + "uri");
            if (uriNode != null)
                resource.Uri = new Uri(uriNode.Value);

            var derefUriNode = resourceElement.Element(capNamespace + "derefUri");
            if (derefUriNode != null)
                resource.DereferencedUri = derefUriNode.Value;

            var digestNode = resourceElement.Element(capNamespace + "digest");
            if (digestNode != null)
                resource.Digest = digestNode.Value;

            return resource;
        }
    }
}
