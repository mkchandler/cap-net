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
            var elements = xdoc.Descendants(XmlCreator.CAP11Namespace + "alert");
            if (!elements.Any())
            {
                elements = xdoc.Descendants(XmlCreator.CAP12Namespace + "alert");
            }

            return from alertElement in elements
                   select ParseAlert(alertElement);
        }

        private static Alert ParseAlert(XElement alertElement)
        {
            Alert alert = new Alert();

            var infoNode = alertElement.Element(XmlCreator.CAP12Namespace + "info");
            if (infoNode != null)
            {
                var info = ParseInfo(infoNode);
                alert.Info.Add(info);
            }

            var incidentsNode = alertElement.Element(XmlCreator.CAP12Namespace + "incidents");
            if (incidentsNode != null)
            {
                alert.Incidents = incidentsNode.Value;
            }

            var referencesNode = alertElement.Element(XmlCreator.CAP12Namespace + "references");
            if (referencesNode != null)
            {
                alert.References = referencesNode.Value;
            }

            var noteNode = alertElement.Element(XmlCreator.CAP12Namespace + "note");
            if (noteNode != null)
            {
                alert.Note = noteNode.Value;
            }

            var codeNode = alertElement.Element(XmlCreator.CAP12Namespace + "code");
            if (codeNode != null)
            {
                alert.Code = codeNode.Value;
            }

            var addressesNode = alertElement.Element(XmlCreator.CAP12Namespace + "addresses");
            if (addressesNode != null)
            {
                alert.Addresses = addressesNode.Value;
            }

            var restrictionNode = alertElement.Element(XmlCreator.CAP12Namespace + "restriction");
            if (restrictionNode != null)
            {
                alert.Restriction = restrictionNode.Value;
            }

            var scopeNode = alertElement.Element(XmlCreator.CAP12Namespace + "scope");
            if (scopeNode != null)
            {
                alert.Scope = (Scope)Enum.Parse(typeof(Scope), scopeNode.Value);
            }

            var sourceNode = alertElement.Element(XmlCreator.CAP12Namespace + "source");
            if (sourceNode != null)
            {
                alert.Source = sourceNode.Value;
            }

            var msgTypeNode = alertElement.Element(XmlCreator.CAP12Namespace + "msgType");
            if (msgTypeNode != null)
            {
                alert.MessageType = (MessageType)Enum.Parse(typeof(MessageType), msgTypeNode.Value);
            }

            var statusNode = alertElement.Element(XmlCreator.CAP12Namespace + "status");
            if (statusNode != null)
            {
                alert.Status = (Status)Enum.Parse(typeof(Status), statusNode.Value);
            }

            var sentNode = alertElement.Element(XmlCreator.CAP12Namespace + "sent");
            if (sentNode != null)
            {
                alert.Sent = DateTimeOffset.Parse(sentNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNode = alertElement.Element(XmlCreator.CAP12Namespace + "sender");
            if (senderNode != null)
            {
                alert.Sender = senderNode.Value;
            }

            var identifierNode = alertElement.Element(XmlCreator.CAP12Namespace + "identifier");
            if (identifierNode != null)
            {
                alert.Identifier = identifierNode.Value;
            }

            return alert;
        }

        private static Info ParseInfo(XElement infoElement)
        {
            var info = new Info();

            var languageNode = infoElement.Element(XmlCreator.CAP12Namespace + "language");
            if (languageNode != null)
                info.Language = languageNode.Value;

            var categoryQuery = from categoryNode in infoElement.Elements(XmlCreator.CAP12Namespace + "category")
                                where categoryNode != null
                                select (Category)Enum.Parse(typeof(Category), categoryNode.Value);

            foreach (var category in categoryQuery)
            {
                info.Categories.Add(category);
            }

            var eventNode = infoElement.Element(XmlCreator.CAP12Namespace + "event");
            if (eventNode != null)
            {
                info.Event = eventNode.Value;
            }

            var responseTypeNode = infoElement.Element(XmlCreator.CAP12Namespace + "responseType");
            if (responseTypeNode != null)
            {
                info.ResponseType = responseTypeNode.Value;
            }

            var urgencyNode = infoElement.Element(XmlCreator.CAP12Namespace + "urgency");
            if (urgencyNode != null)
            {
                info.Urgency = (Urgency)Enum.Parse(typeof(Urgency), urgencyNode.Value);
            }

            var certaintyNode = infoElement.Element(XmlCreator.CAP12Namespace + "certainty");
            if (certaintyNode != null)
            {
                if (certaintyNode.Value == "Very Likely")
                {
                    info.Certainty = Certainty.Likely;
                }
                else
                {
                    info.Certainty = (Certainty)Enum.Parse(typeof(Certainty), certaintyNode.Value);
                }
            }

            var audienceNode = infoElement.Element(XmlCreator.CAP12Namespace + "audience");
            if (audienceNode != null)
            {
                info.Audience = audienceNode.Value;
            }

            var eventCodeNode = infoElement.Element(XmlCreator.CAP12Namespace + "eventCode");
            if (eventCodeNode != null)
            {
                info.EventCode = eventCodeNode.Value;
            }

            var effectiveNode = infoElement.Element(XmlCreator.CAP12Namespace + "effective");
            if (effectiveNode != null)
            {
                info.Effective = DateTimeOffset.Parse(effectiveNode.Value, CultureInfo.InvariantCulture);
            }

            var severityNode = infoElement.Element(XmlCreator.CAP12Namespace + "severity");
            if (severityNode != null)
            {
                Severity severity;
                if (Enum.TryParse(severityNode.Value, out severity))
                {
                    info.Severity = severity;
                }
                else
                {
                    info.Severity = null;
                }
            }

            var onsetNode = infoElement.Element(XmlCreator.CAP12Namespace + "onset");
            if (onsetNode != null)
            {
                info.Onset = DateTimeOffset.Parse(onsetNode.Value, CultureInfo.InvariantCulture);
            }

            var expiresNode = infoElement.Element(XmlCreator.CAP12Namespace + "expires");
            if (expiresNode != null)
            {
                info.Expires = DateTimeOffset.Parse(expiresNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNameNode = infoElement.Element(XmlCreator.CAP12Namespace + "senderName");
            if (senderNameNode != null)
            {
                info.SenderName = senderNameNode.Value;
            }

            var headlineNode = infoElement.Element(XmlCreator.CAP12Namespace + "headline");
            if (headlineNode != null)
            {
                info.Headline = headlineNode.Value;
            }

            var descriptionNode = infoElement.Element(XmlCreator.CAP12Namespace + "description");
            if (descriptionNode != null)
            {
                info.Description = descriptionNode.Value;
            }

            var instructionNode = infoElement.Element(XmlCreator.CAP12Namespace + "instruction");
            if (instructionNode != null)
            {
                info.Instruction = instructionNode.Value;
            }

            var webNode = infoElement.Element(XmlCreator.CAP12Namespace + "web");
            if (webNode != null)
            {
                info.Web = webNode.Value;
            }

            var contactNode = infoElement.Element(XmlCreator.CAP12Namespace + "contact");
            if (contactNode != null)
            {
                info.Contact = contactNode.Value;
            }

            var parameterQuery = from parameter in infoElement.Elements(XmlCreator.CAP12Namespace + "parameter")
                                 let valueNameNode = parameter.Element(XmlCreator.CAP12Namespace + "valueName")
                                 let valueNode = parameter.Element(XmlCreator.CAP12Namespace + "value")
                                 where valueNameNode != null && valueNode != null
                                 select new Parameter(valueNameNode.Value, valueNode.Value);
                                 
            foreach (var parameter in parameterQuery)
            {
                info.Parameters.Add(parameter);
            }

            var resourceQuery = from resourceNode in infoElement.Elements(XmlCreator.CAP12Namespace+"resource")
                                where resourceNode != null
                                select ParseResource(resourceNode);

            foreach ( var resource in resourceQuery)
            {
                info.Resources.Add(resource);
            }

            var areaQuery = from areaNode in infoElement.Elements(XmlCreator.CAP12Namespace + "area")
                            where areaNode != null
                            select ParseArea(areaNode);

            foreach ( var area in areaQuery )
            {
                info.Areas.Add(area);
            }

            return info;
        }

        private static Area ParseArea(XElement areaElement)
        {
            var area = new Area();
            
            var areaDescNode = areaElement.Element(XmlCreator.CAP12Namespace + "areaDesc");
            if (areaDescNode != null)
                area.Description = areaDescNode.Value;

            var polygonQuery = from polygonNode in areaElement.Elements(XmlCreator.CAP12Namespace + "polygon")
                               where polygonNode != null
                               select polygonNode.Value;
            
            foreach (var polygonValue in polygonQuery )
                area.Polygons.Add(polygonValue);

            var circleQuery = from circleNode in areaElement.Elements(XmlCreator.CAP12Namespace + "circle")
                              where circleNode != null
                              select circleNode.Value;

            foreach (var circleValue in circleQuery)
                area.Circles.Add(circleValue);
            
            return area;
        }

        private static Resource ParseResource(XElement resourceElement)
        {
            var resource = new Resource();
            
            //<resource>
            //  <resourceDesc>Image file (GIF)</resourceDesc>
            //  <mimeType>image/gif</mimeType>
            //  <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            //</resource>

            var resourceDescNode = resourceElement.Element(XmlCreator.CAP12Namespace + "resourceDesc");
            if (resourceDescNode != null)
                resource.Description = resourceDescNode.Value;

            var mimeTypeNode = resourceElement.Element(XmlCreator.CAP12Namespace + "mimeType");
            if (mimeTypeNode != null)
                resource.MimeType = mimeTypeNode.Value;

            var uriNode = resourceElement.Element(XmlCreator.CAP12Namespace + "uri");
            if (uriNode != null)
                resource.Uri = uriNode.Value;

            return resource;
        }
    }
}
