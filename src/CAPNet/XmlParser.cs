using System;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace CAPNet
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Alert Parse(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);
            var alert = ParseInternal(document);
            return alert;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static Alert Parse(XmlDocument xml)
        {
            var alert = ParseInternal(xml);
            return alert;
        }

        private static Alert ParseInternal(XmlDocument document)
        {
            var alert = new Alert();

            XmlNodeList elements = document.GetElementsByTagName("alert", "urn:oasis:names:tc:emergency:cap:1.1");

            if (elements.Count == 0)
            {
                // try CAP 1.2
                elements = document.GetElementsByTagName("alert", "urn:oasis:names:tc:emergency:cap:1.2");
            }

            foreach (XmlNode element in elements)
            {
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
                            var info = new Info();
                            foreach (XmlNode infoNode in alertNode.ChildNodes)
                            {
                                switch (infoNode.Name)
                                {
                                    case "language":
                                        info.Language = infoNode.InnerText;
                                        break;
                                    case "category":
                                        //info.Category = infoNode.InnerText;
                                        break;
                                    case "event":
                                        info.Event = infoNode.InnerText;
                                        break;
                                    case "responseType":
                                        info.ResponseType = infoNode.InnerText;
                                        break;
                                    case "urgency":
                                        info.Urgency = infoNode.InnerText;
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
                                        info.Certainty = infoNode.InnerText;
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
                                    case "area":
                                        var area = new Area();
                                        foreach (XmlNode areaNode in infoNode.ChildNodes)
                                        {
                                            switch (areaNode.Name)
                                            {
                                                case "areaDesc":
                                                    area.Description = areaNode.InnerText;
                                                    break;
                                                case "polygon":
                                                    area.Polygon = areaNode.InnerText;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                        info.Areas.Add(area);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            alert.Info.Add(info);
                            break;
                        default:
                            break;
                    }
                }
            }

            return alert;
        }
    }
}
