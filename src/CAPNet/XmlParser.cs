using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

using CAPNet.Models;

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
        public static List<Alert> Parse(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            var alertList = ParseInternal(document);
            return alertList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static List<Alert> Parse(XmlDocument xml)
        {
            var alertList = ParseInternal(xml);

            return alertList;
        }

        private static List<Alert> ParseInternal(XmlDocument document)
        {
            var alertList = new List<Alert>();

            XmlNodeList elements = document.GetElementsByTagName("alert", "urn:oasis:names:tc:emergency:cap:1.1");

            if (elements.Count == 0)
            {
                // try CAP 1.2
                elements = document.GetElementsByTagName("alert", "urn:oasis:names:tc:emergency:cap:1.2");
            }

            foreach (XmlNode element in elements)
            {
                var alert = new Alert();

                foreach (XmlNode alertNode in element.ChildNodes)
                {
                    switch (alertNode.Name)
                    {
                        case "identifier":
                            alert.Identifier = alertNode.InnerText;
                            break;
                        case "sender":
                            alert.Sender = alertNode.InnerText;
                            break;
                        case "sent":
                            alert.Sent = DateTimeOffset.Parse(alertNode.InnerText, CultureInfo.InvariantCulture);
                            break;
                        case "status":
                            alert.Status = (Status)Enum.Parse(typeof(Status), alertNode.InnerText);
                            break;
                        case "msgType":
                            alert.MessageType = (MessageType)Enum.Parse(typeof(MessageType), alertNode.InnerText);
                            break;
                        case "source":
                            alert.Source = alertNode.InnerText;
                            break;
                        case "scope":
                            alert.Scope = (Scope)Enum.Parse(typeof(Scope), alertNode.InnerText);
                            break;
                        case "restriction":
                            alert.Restriction = alertNode.InnerText;
                            break;
                        case "addresses":
                            alert.Addresses = alertNode.InnerText;
                            break;
                        case "code":
                            alert.Code = alertNode.InnerText;
                            break;
                        case "note":
                            alert.Note = alertNode.InnerText;
                            break;
                        case "references":
                            alert.References = alertNode.InnerText;
                            break;
                        case "incidents":
                            alert.Incidents = alertNode.InnerText;
                            break;
                        case "info":
                            var info = ParseInfo(alertNode);
                            alert.Info.Add(info);
                            break;
                        default:
                            break;
                    }
                }

                alertList.Add(alert);
            }

            return alertList;
        }

        private static Info ParseInfo(XmlNode alertNode)
        {
            var translatedAlertNode = XDocument.Parse(alertNode.OuterXml).Root;
            var info = new Info();

            var languageNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace+"language");
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
                info.EventCode = eventCodeNode.Value;
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

            var contactNode = translatedAlertNode.Element(XmlCreator.CAP12Namespace+"contact");
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

                info.Parameters.Add(valueName, value);
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

        private static Area ParseArea(XmlNode areaNode)
        {
            var translatedAreaNode = XDocument.Parse(areaNode.OuterXml).Root;
            return ParseArea(translatedAreaNode);
        }

        private static Area ParseArea(XElement translatedAreaNode)
        {
            var area = new Area();

            var areaDescNode = translatedAreaNode.Element(XmlCreator.CAP12Namespace + "areaDesc");
            if (areaDescNode != null)
                area.Description = areaDescNode.Value;

            var polygonNode = translatedAreaNode.Element(XmlCreator.CAP12Namespace + "polygon");
            if (polygonNode != null)
                area.Polygon = polygonNode.Value;

            return area;
        }

        private static Resource ParseResource(XmlNode resourceNode)
        {
            var translatedResourceNode = XDocument.Parse(resourceNode.OuterXml).Root;
            return ParseResource(translatedResourceNode);
        }

        private static Resource ParseResource(XElement translatedResourceNode)
        {
            var resource = new Resource();

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
