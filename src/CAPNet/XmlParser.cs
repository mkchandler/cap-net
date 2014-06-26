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
            var info = new Info();
            foreach (XmlNode infoNode in alertNode.ChildNodes)
            {
                switch (infoNode.Name)
                {
                    case "language":
                        info.Language = infoNode.InnerText;
                        break;
                    case "category":
                        var category = (Category)Enum.Parse(typeof(Category), infoNode.InnerText);
                        info.Categories.Add(category);
                        break;
                    case "event":
                        info.Event = infoNode.InnerText;
                        break;
                    case "responseType":
                        info.ResponseType = infoNode.InnerText;
                        break;
                    case "urgency":
                        info.Urgency = (Urgency)Enum.Parse(typeof(Urgency), infoNode.InnerText);
                        break;
                    case "severity":
                        Severity severity;
                        if (Enum.TryParse(infoNode.InnerText, out severity))
                        {
                            info.Severity = severity;
                        }
                        else
                        {
                            info.Severity = null;
                        }
                        break;
                    case "certainty":
                        if (infoNode.InnerText == "Very Likely")
                        {
                            info.Certainty = Certainty.Likely;
                        }
                        else
                        {
                            info.Certainty = (Certainty)Enum.Parse(typeof(Certainty), infoNode.InnerText);
                        }
                        break;
                    case "audience":
                        info.Audience = infoNode.InnerText;
                        break;
                    case "eventCode":
                        info.EventCode = infoNode.InnerText;
                        break;
                    case "effective":
                        info.Effective = DateTimeOffset.Parse(infoNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "onset":
                        info.Onset = DateTimeOffset.Parse(infoNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "expires":
                        info.Expires = DateTimeOffset.Parse(infoNode.InnerText, CultureInfo.InvariantCulture);
                        break;
                    case "senderName":
                        info.SenderName = infoNode.InnerText;
                        break;
                    case "headline":
                        info.Headline = infoNode.InnerText;
                        break;
                    case "description":
                        info.Description = infoNode.InnerText;
                        break;
                    case "instruction":
                        info.Instruction = infoNode.InnerText;
                        break;
                    case "web":
                        info.Web = infoNode.InnerText;
                        break;
                    case "contact":
                        info.Contact = infoNode.InnerText;
                        break;
                    case "parameter":
                        string valueName = null;
                        string value = null;
                        foreach (XmlNode parameterNode in infoNode.ChildNodes)
                        {
                            switch (parameterNode.Name)
                            {
                                case "valueName":
                                    valueName = parameterNode.InnerText;
                                    break;
                                case "value":
                                    value = parameterNode.InnerText;
                                    break;
                                default:
                                    break;
                            }
                        }
                        info.Parameters.Add(valueName, value);
                        break;
                    case "resource":
                        var resource = ParseResource(infoNode);
                        info.Resources.Add(resource);
                        break;
                    case "area":
                        var area = ParseArea(infoNode);
                        info.Areas.Add(area);
                        break;
                    default:
                        break;
                }
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
