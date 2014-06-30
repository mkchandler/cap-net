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

        private static Info ParseInfo(XNode alertNode)
        {
            var translatedAlertNode = (XElement)alertNode;
            var info = new Info();

            var languageNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "language");
            if (languageNode != null)
                info.Language = languageNode.Value;

            var categoryNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "category");
            if (categoryNode != null)
            {
                var category = (Category)Enum.Parse(typeof(Category), categoryNode.Value);
                info.Categories.Add(category);
            }

            var eventNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "event");
            if (eventNode != null)
            {
                info.Event = eventNode.Value;
            }

            var responseTypeNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "responseType");
            if (responseTypeNode != null)
            {
                info.ResponseType = responseTypeNode.Value;
            }

            var urgencyNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "urgency");
            if (urgencyNode != null)
            {
                info.Urgency = (Urgency)Enum.Parse(typeof(Urgency), urgencyNode.Value);
            }

            var certaintyNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "certainty");
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

            var audienceNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "audience");
            if (audienceNode != null)
            {
                info.Audience = audienceNode.Value;
            }

            var eventCodeNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "eventCode");
            if (eventCodeNode != null)
            {
                string valueName = null;
                string value = null;

                var valueNameNode = eventCodeNode.Element(XmlCreator.CAP12Namespace + "valueName");
                if (valueNameNode != null)
                {
                    valueName = valueNameNode.Value;
                }

                var valueNode = eventCodeNode.Element(XmlCreator.CAP12Namespace + "value");
                if (valueNode != null)
                {
                    value = valueNode.Value;
                }

                info.EventCodes.Add(new EventCode(valueName, value));
            }

            var effectiveNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "effective");
            if (effectiveNode != null)
            {
                info.Effective = DateTimeOffset.Parse(effectiveNode.Value, CultureInfo.InvariantCulture);
            }

            var severityNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "severity");
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

            var onsetNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "onset");
            if (onsetNode != null)
            {
                info.Onset = DateTimeOffset.Parse(onsetNode.Value, CultureInfo.InvariantCulture);
            }

            var expiresNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "expires");
            if (expiresNode != null)
            {
                info.Expires = DateTimeOffset.Parse(expiresNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNameNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "senderName");
            if (senderNameNode != null)
            {
                info.SenderName = senderNameNode.Value;
            }

            var headlineNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "headline");
            if (headlineNode != null)
            {
                info.Headline = headlineNode.Value;
            }

            var descriptionNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "description");
            if (descriptionNode != null)
            {
                info.Description = descriptionNode.Value;
            }

            var instructionNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "instruction");
            if (instructionNode != null)
            {
                info.Instruction = instructionNode.Value;
            }

            var webNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "web");
            if (webNode != null)
            {
                info.Web = webNode.Value;
            }

            var contactNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "contact");
            if (contactNode != null)
            {
                info.Contact = contactNode.Value;
            }

            var parameterNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "parameter");
            if (parameterNode != null)
            {
                string valueName = null;
                string value = null;

                var valueNameNode = parameterNode.Element(XmlCreator.CAP12Namespace + "valueName");
                if (valueNameNode != null)
                {
                    valueName = valueNameNode.Value;
                }

                var valueNode = parameterNode.Element(XmlCreator.CAP12Namespace + "value");
                if (valueNode != null)
                {
                    value = valueNode.Value;
                }

                info.Parameters.Add(new Parameter(valueName, value));
            }

            var resourceNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "resource");
            if (resourceNode != null)
            {
                var resource = ParseResource(resourceNode);
                info.Resources.Add(resource);
            }

            var areaNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace + "area");
            if (areaNode != null)
            {
                var area = ParseArea(areaNode);
                info.Areas.Add(area);
            }

            return info;
        }

        private static Area ParseArea(XNode areaNode)
        {
            var area = new Area();
            var translatedAreaNode = (XElement)areaNode;

            var areaDescNode = translatedAreaNode.Element(XmlCreator.CAP12Namespace + "areaDesc");
            if (areaDescNode != null)
                area.Description = areaDescNode.Value;

            var polygonNode = translatedAreaNode.Element(XmlCreator.CAP12Namespace + "polygon");
            if (polygonNode != null)
                area.Polygon = polygonNode.Value;

            return area;
        }

        private static Resource ParseResource(XNode resourceNode)
        {
            var resource = new Resource();
            var translatedResourceNode = (XElement)resourceNode;

            //<resource>
            //  <resourceDesc>Image file (GIF)</resourceDesc>
            //  <mimeType>image/gif</mimeType>
            //  <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            //</resource>

            var resourceDescNode = translatedResourceNode.Element(XmlCreator.CAP12Namespace + "resourceDesc");
            if (resourceDescNode != null)
                resource.Description = resourceDescNode.Value;

            var mimeTypeNode = translatedResourceNode.Element(XmlCreator.CAP12Namespace + "mimeType");
            if (mimeTypeNode != null)
                resource.MimeType = mimeTypeNode.Value;

            var uriNode = translatedResourceNode.Element(XmlCreator.CAP12Namespace + "uri");
            if (uriNode != null)
                resource.Uri = uriNode.Value;

            return resource;
        }
    }
}