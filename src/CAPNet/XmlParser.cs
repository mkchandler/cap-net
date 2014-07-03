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

        private static XNamespace _usedNameSpace;

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
            var elementsCap11 = xdoc.Descendants(XmlCreator.CAP11Namespace + "alert");

            if (!elementsCap11.Any())
                _usedNameSpace = XmlCreator.CAP12Namespace;
            else
                _usedNameSpace = XmlCreator.CAP11Namespace;

            var elements = xdoc.Descendants(_usedNameSpace + "alert");

            return from alertElement in elements
                   select ParseAlert(alertElement);
        }

        private static Alert ParseAlert(XElement alertElement)
        {
            Alert alert = new Alert();

            var infoNode = alertElement.Element(_usedNameSpace + "info");
            if (infoNode != null)
            {
                var info = ParseInfo(infoNode);
                alert.Info.Add(info);
            }

            var incidentsNode = alertElement.Element(_usedNameSpace + "incidents");
            if (incidentsNode != null)
            {
                alert.Incidents = incidentsNode.Value;
            }

            var referencesNode = alertElement.Element(_usedNameSpace + "references");
            if (referencesNode != null)
            {
                alert.References = referencesNode.Value;
            }

            var noteNode = alertElement.Element(_usedNameSpace + "note");
            if (noteNode != null)
            {
                alert.Note = noteNode.Value;
            }

            var codeNode = alertElement.Element(_usedNameSpace + "code");
            if (codeNode != null)
            {
                alert.Code = codeNode.Value;
            }

            var addressesNode = alertElement.Element(_usedNameSpace + "addresses");
            if (addressesNode != null)
            {
                alert.Addresses = addressesNode.Value;
            }

            var restrictionNode = alertElement.Element(_usedNameSpace + "restriction");
            if (restrictionNode != null)
            {
                alert.Restriction = restrictionNode.Value;
            }

            var scopeNode = alertElement.Element(_usedNameSpace + "scope");
            if (scopeNode != null)
            {
                alert.Scope = (Scope)Enum.Parse(typeof(Scope), scopeNode.Value);
            }

            var sourceNode = alertElement.Element(_usedNameSpace + "source");
            if (sourceNode != null)
            {
                alert.Source = sourceNode.Value;
            }

            var msgTypeNode = alertElement.Element(_usedNameSpace + "msgType");
            if (msgTypeNode != null)
            {
                alert.MessageType = (MessageType)Enum.Parse(typeof(MessageType), msgTypeNode.Value);
            }

            var statusNode = alertElement.Element(_usedNameSpace + "status");
            if (statusNode != null)
            {
                alert.Status = (Status)Enum.Parse(typeof(Status), statusNode.Value);
            }

            var sentNode = alertElement.Element(_usedNameSpace + "sent");
            if (sentNode != null)
            {
                alert.Sent = DateTimeOffset.Parse(sentNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNode = alertElement.Element(_usedNameSpace + "sender");
            if (senderNode != null)
            {
                alert.Sender = senderNode.Value;
            }

            var identifierNode = alertElement.Element(_usedNameSpace + "identifier");
            if (identifierNode != null)
            {
                alert.Identifier = identifierNode.Value;
            }

            return alert;
        }

        private static Info ParseInfo(XElement infoElement)
        {
            var info = new Info();

            var languageNode = infoElement.Element(_usedNameSpace + "language");
            if (languageNode != null)
                info.Language = languageNode.Value;

            var categoryQuery = from categoryNode in infoElement.Elements(_usedNameSpace + "category")
                                where categoryNode != null
                                select (Category)Enum.Parse(typeof(Category), categoryNode.Value);

            foreach (var category in categoryQuery)
            {
                info.Categories.Add(category);
            }

            var eventNode = infoElement.Element(_usedNameSpace + "event");
            if (eventNode != null)
            {
                info.Event = eventNode.Value;
            }

            var responseTypeNode = infoElement.Element(_usedNameSpace + "responseType");
            if (responseTypeNode != null)
            {
                info.ResponseType = responseTypeNode.Value;
            }

            var urgencyNode = infoElement.Element(_usedNameSpace + "urgency");
            if (urgencyNode != null)
            {
                info.Urgency = (Urgency)Enum.Parse(typeof(Urgency), urgencyNode.Value);
            }

            var certaintyNode = infoElement.Element(_usedNameSpace + "certainty");
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

            var audienceNode = infoElement.Element(_usedNameSpace + "audience");
            if (audienceNode != null)
            {
                info.Audience = audienceNode.Value;
            }

            IEnumerable<XElement> eventCodesQuerry =
                from ev in infoElement.Elements(_usedNameSpace + "eventCode")
                where ev != null
                select ev;

            foreach (XElement eventCode in eventCodesQuerry)
            {
                string valueName = eventCode.Element(_usedNameSpace + "valueName").Value;
                string value = eventCode.Element(_usedNameSpace + "value").Value; ;
                info.EventCodes.Add(new EventCode(valueName, value));
            }

            var effectiveNode = infoElement.Element(_usedNameSpace + "effective");
            if (effectiveNode != null)
            {
                info.Effective = DateTimeOffset.Parse(effectiveNode.Value, CultureInfo.InvariantCulture);
            }

            var severityNode = infoElement.Element(_usedNameSpace + "severity");
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

            var onsetNode = infoElement.Element(_usedNameSpace + "onset");
            if (onsetNode != null)
            {
                info.Onset = DateTimeOffset.Parse(onsetNode.Value, CultureInfo.InvariantCulture);
            }

            var expiresNode = infoElement.Element(_usedNameSpace + "expires");
            if (expiresNode != null)
            {
                info.Expires = DateTimeOffset.Parse(expiresNode.Value, CultureInfo.InvariantCulture);
            }

            var senderNameNode = infoElement.Element(_usedNameSpace + "senderName");
            if (senderNameNode != null)
            {
                info.SenderName = senderNameNode.Value;
            }

            var headlineNode = infoElement.Element(_usedNameSpace + "headline");
            if (headlineNode != null)
            {
                info.Headline = headlineNode.Value;
            }

            var descriptionNode = infoElement.Element(_usedNameSpace + "description");
            if (descriptionNode != null)
            {
                info.Description = descriptionNode.Value;
            }

            var instructionNode = infoElement.Element(_usedNameSpace + "instruction");
            if (instructionNode != null)
            {
                info.Instruction = instructionNode.Value;
            }

            var webNode = infoElement.Element(_usedNameSpace + "web");
            if (webNode != null)
            {
                info.Web = new Uri(webNode.Value);
            }

            var contactNode = infoElement.Element(_usedNameSpace + "contact");
            if (contactNode != null)
            {
                info.Contact = contactNode.Value;
            }

            var parameterQuery = from parameter in infoElement.Elements(_usedNameSpace + "parameter")
                                 let valueNameNode = parameter.Element(_usedNameSpace + "valueName")
                                 let valueNode = parameter.Element(_usedNameSpace + "value")
                                 where valueNameNode != null && valueNode != null
                                 select new Parameter(valueNameNode.Value, valueNode.Value);

            foreach (var parameter in parameterQuery)
            {
                info.Parameters.Add(parameter);
            }

            var resourceQuery = from resourceNode in infoElement.Elements(_usedNameSpace + "resource")
                                where resourceNode != null
                                select ParseResource(resourceNode);

            foreach (var resource in resourceQuery)
            {
                info.Resources.Add(resource);
            }

            var areaQuery = from areaNode in infoElement.Elements(_usedNameSpace + "area")
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

            var areaDescNode = areaElement.Element(_usedNameSpace + "areaDesc");
            if (areaDescNode != null)
                area.Description = areaDescNode.Value;

            var polygonQuery = from polygonNode in areaElement.Elements(_usedNameSpace + "polygon")
                               where polygonNode != null
                               select polygonNode.Value;

            foreach (var polygonValue in polygonQuery)
                area.Polygons.Add(polygonValue);

            var circleQuery = from circleNode in areaElement.Elements(_usedNameSpace + "circle")
                              where circleNode != null
                              select circleNode.Value;

            foreach (var circleValue in circleQuery)
                area.Circles.Add(circleValue);

            var geoCodeQuery = from geoCodeNode in areaElement.Elements(_usedNameSpace + "geocode")
                               where geoCodeNode != null
                               select geoCodeNode;

            var altitudeNode = areaElement.Element(_usedNameSpace + "altitude");
            if (altitudeNode != null)
                area.Altitude = altitudeNode.Value;

            var ceilingNode = areaElement.Element(_usedNameSpace + "ceiling");
            if (ceilingNode != null)
                area.Ceiling = ceilingNode.Value;

            foreach (XElement geoCodeValue in geoCodeQuery)
            {
                string valueName = geoCodeValue.Element(_usedNameSpace + "valueName").Value;
                string value = geoCodeValue.Element(_usedNameSpace + "value").Value;

                area.GeoCodes.Add(new GeoCode(valueName, value));
            }
            return area;
        }

        private static Resource ParseResource(XElement resourceElement)
        {
            var resource = new Resource();

            //<resource>
            //    <resourceDesc>Image file (GIF)</resourceDesc>
            //    <mimeType>image/gif</mimeType>
            //    <size>1</size>
            //    <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            //    <derefUri>derefUri</derefUri>
            //    <digest>digest</digest>
            //</resource>

            var resourceDescNode = resourceElement.Element(_usedNameSpace + "resourceDesc");
            if (resourceDescNode != null)
                resource.Description = resourceDescNode.Value;

            var mimeTypeNode = resourceElement.Element(_usedNameSpace + "mimeType");
            if (mimeTypeNode != null)
                resource.MimeType = mimeTypeNode.Value;

            var sizeNode = resourceElement.Element(_usedNameSpace + "size");
            if (sizeNode != null)
                resource.Size = int.Parse(sizeNode.Value);

            var uriNode = resourceElement.Element(_usedNameSpace + "uri");
            if (uriNode != null)
                resource.Uri = new Uri(uriNode.Value);

            var derefUriNode = resourceElement.Element(_usedNameSpace + "derefUri");
            if (derefUriNode != null)
                resource.DereferencedUri = derefUriNode.Value;

            var digestNode = resourceElement.Element(_usedNameSpace + "digest");
            if (digestNode != null)
                resource.Digest = digestNode.Value;

            return resource;
        }
    }
}
