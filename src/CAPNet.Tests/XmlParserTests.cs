using System;
using System.Linq;
using System.Collections.Generic;

using CAPNet.Models;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlParserTests
    {
        [Fact]
        public void CanReadMultipleAlertsFromXML()
        {
            var alertList = XmlParser.Parse(Xml.MultipleThunderstorm12Xml);
            Assert.Equal(2, alertList.Count());
        }

        [Fact]
        public void ReadingXmlWithNoAlertReturnsEmptyList()
        {
            var alertList = XmlParser.Parse("<a><b/><c/></a>");

            Assert.Empty(alertList);
        }

        [Fact]
        public void CanReadCAP12Example()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.NotNull(alert.Info.ElementAt(0).Areas.ElementAt(0).Polygons);
        }

        [Fact]
        public void SentTimeHasTimeZone()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.Equal(TimeSpan.FromHours(-7), alert.Sent.Offset);
        }

        [Fact]
        public void DatesInInfoHaveTimeZones()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12AllDatesXml).First();

            var info = alert.Info.ElementAt(0);

            Assert.Equal(TimeSpan.FromHours(-7), info.Effective.Offset);
            Assert.Equal(TimeSpan.FromHours(-7), info.Onset.Offset);
            Assert.Equal(TimeSpan.FromHours(-7), info.Expires.Offset);
        }

        [Fact]
        public void CanReadAlertStatus()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.Equal(Status.Actual, alert.Status);
        }

        [Fact]
        public void CanReadAlertMessageType()
        {
            var alert = XmlParser.Parse(Xml.ThunderstormUpdate12Xml).First();
            Assert.Equal(MessageType.Update, alert.MessageType);
        }

        [Fact]
        public void CanReadAlertScope()
        {
            var alert = XmlParser.Parse(Xml.ThunderstormUpdate12Xml).First();
            Assert.Equal(Scope.Restricted, alert.Scope);
            Assert.Contains("glasses", alert.Restriction);
        }

        [Fact]
        public void InfoHasMetCategory()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.Contains(Category.Met, alert.Info.ElementAt(0).Categories);
        }

        [Fact]
        public void UrgencyIsSet()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.Equal(Urgency.Immediate, alert.Info.ElementAt(0).Urgency);
        }

        [Fact]
        public void CertaintyIsSet()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.Equal(Certainty.Observed, alert.Info.ElementAt(0).Certainty);
        }

        /// <summary>
        /// For backward compatibility with CAP 1.0, the deprecated value of “Very Likely” SHOULD be treated as equivalent to “Likely”.
        /// </summary>
        [Fact]
        public void VeryLikelyIsTreatedAsLikely()
        {
            var alert = XmlParser.Parse(Xml.VeryLikelyOrangeAlertXml).First();
            Assert.Equal(Certainty.Likely, alert.Info.ElementAt(0).Certainty);
        }

        [Fact]
        public void CanParseXmlWithCircle()
        {
            var alert = XmlParser.Parse(Xml.circleXml).First();
            Assert.NotNull(alert);

            var circle = alert.Info.ElementAt(0).Areas.ElementAt(0).Circles;
            Assert.Equal(1, circle.Count());

            //<circle>32.9525,-115.5527 0</circle>  
            Assert.Equal("32.9525,-115.5527 0", circle.First());
        }

        [Fact]
        public void CanParseXmlWithMultipleCircles()
        {
            var alert = XmlParser.Parse(Xml.MultipleCircleXml).First();
            Assert.NotNull(alert);

            var circles = alert.Info.ElementAt(0).Areas.ElementAt(0).Circles;
            Assert.Equal(2, circles.Count());

            //<circle>32.9525,-115.5527 0</circle>  
            Assert.Equal("32.9525,-115.5527 0", circles.First());

            //<circle>62.9525,-55.5527 0</circle>
            Assert.Equal("62.9525,-55.5527 0", circles.Last());
        }

        [Fact]
        public void CanParseXmlWithPolygon()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.NotNull(alert);

            var polygons = alert.Info.ElementAt(0).Areas.ElementAt(0).Polygons;
            Assert.Equal(1, polygons.Count());

            //<polygon>38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14</polygon>
            Assert.Equal("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14", polygons.First());
        }

        [Fact]
        public void CanParseXmlWithMultipleGeoCodes()
        {
            var alert = XmlParser.Parse(Xml.Thunderstorm12Xml).First();
            Assert.NotNull(alert);

            ICollection<GeoCode> geoCodes = alert.Info.ElementAt(0).Areas.ElementAt(0).GeoCodes;
            Assert.Equal(3, geoCodes.Count());


            //<geocode>
            //   <valueName>SAME</valueName>
            //   <value>006109</value>
            //</geocode>
            Assert.Equal("SAME", geoCodes.ElementAt(0).ValueName);
            Assert.Equal("006109", geoCodes.ElementAt(0).Value);

            //<geocode>
            //  <valueName>SAME</valueName>
            //  <value>006009</value>
            //</geocode>
            Assert.Equal("SAME", geoCodes.ElementAt(1).ValueName);
            Assert.Equal("006009", geoCodes.ElementAt(1).Value);

            //<geocode>
            //  <valueName>SAME</valueName>
            //  <value>006003</value>
            //</geocode>
            Assert.Equal("SAME", geoCodes.ElementAt(2).ValueName);
            Assert.Equal("006003", geoCodes.ElementAt(2).Value);

        }

        [Fact]
        public void CanParseXmlWithMultiplePolygons()
        {
            var alert = XmlParser.Parse(Xml.MultipleThunderstorm12Xml).First();
            Assert.NotNull(alert);

            var polygons = alert.Info.ElementAt(0).Areas.ElementAt(0).Polygons;
            Assert.Equal(2, polygons.Count());

            //<polygon>38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14</polygon>
            var firstPolygon = polygons.First();
            Assert.Equal("38.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14", firstPolygon);

            //<polygon>58.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 38.47,-120.14</polygon>
            var lastPolygon = polygons.Last();
            Assert.Equal("58.47,-120.14 38.34,-119.95 38.52,-119.74 38.62,-119.89 58.47,-120.14", lastPolygon);
        }

        [Fact]
        public void CanParseXmlWithMultipleCategories()
        {
            var alert = XmlParser.Parse(Xml.MultipleParameterTestXml).First();

            var info = alert.Info.ElementAt(0);
            Assert.Equal(2, info.Categories.Count);

            //    <category>Security</category>
            Assert.Contains(Category.Security, info.Categories);
            //    <category>Safety</category>
            Assert.Contains(Category.Safety, info.Categories);
        }

        [Fact]
        public void CanParseXmlWithMultipleResources()
        {
            var alert = XmlParser.Parse(Xml.MultipleParameterTestXml).First();

            var info = alert.Info.ElementAt(0);

            //    <resource>
            Assert.Equal(2, info.Resources.Count);

            var firstResource = info.Resources.First();
            //      <resourceDesc>Image file (GIF)</resourceDesc>
            Assert.Equal("Image file (JPG)", firstResource.Description);
            //      <mimeType>image/gif</mimeType>
            Assert.Equal("image/jpg", firstResource.MimeType);
            //      <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            Assert.Equal(new Uri("http://www.dhs.gov/dhspublic/getAdvisoryImage"), firstResource.Uri);
            //    </resource>

            //    <resource>
            var lastResource = info.Resources.Last();
            //      <resourceDesc>Image file (GIF)</resourceDesc>
            Assert.Equal("Image(GIF)", lastResource.Description);
            //      <mimeType>image/gif</mimeType>
            Assert.Equal("image/gif", lastResource.MimeType);
            //      <uri>http://www.dhs.gov/dhspublic/getAdvisoryNoImage</uri>
            Assert.Equal(new Uri("http://www.dhs.gov/dhspublic/getAdvisoryNoImage"), lastResource.Uri);
            //    </resource>
        }

        [Fact]
        public void CanParseXmlWithMultipleAreas()
        {
            var alert = XmlParser.Parse(Xml.MultipleParameterTestXml).First();

            var info = alert.Info.ElementAt(0);

            Assert.Equal(2, info.Areas.Count);

            var firstArea = info.Areas.First();
            //      <areaDesc>U.S.</areaDesc>
            Assert.Equal("U.S.", firstArea.Description);
            //    </area>

            var lastArea = info.Areas.Last();
            //      <areaDesc>Canada</areaDesc>
            Assert.Equal("Canada", lastArea.Description);
            //    </area>
        }

        [Fact]
        public void CanParseXmlWithMultipleParameters()
        {
            var alert = XmlParser.Parse(Xml.MultipleParameterTestXml).First();

            var info = alert.Info.ElementAt(0);
            Assert.Equal(2, info.Parameters.Count);

            //    <parameter>
            var parameter = info.Parameters.First();
            //      <valueName>HSAS1</valueName>
            Assert.Equal("HSAS1", parameter.ValueName);
            //      <value>ORANGE1</value>
            Assert.Equal("ORANGE1", parameter.Value);
            //    </parameter>

            //    <parameter>       
            parameter = info.Parameters.Last();
            //      <valueName>HSAS2</valueName>
            Assert.Equal("HSAS2", parameter.ValueName);
            //      <value>ORANGE2</value>
            Assert.Equal("ORANGE2", parameter.Value);
            //    </parameter>
        }

        [Fact]
        public void MultipleAlertXmlIsParsedCorrectly()
        {
            var alert = XmlParser.Parse(Xml.MultipleAlertXml).First();
            //<?xml version="1.0" encoding="utf-8"?>
            //<alert xmlns="urn:oasis:names:tc:emergency:cap:1.2">
            Assert.NotNull(alert);
            //  <identifier>43b080713727</identifier>
            Assert.Equal("43b080713727", alert.Identifier);
            //  <sender>hsas@dhs.gov</sender>
            Assert.Equal("hsas@dhs.gov", alert.Sender);
            //  <sent>2003-04-02T14:39:01-05:00</sent>
            Assert.Equal(new DateTimeOffset(2003, 4, 2, 14, 39, 1, TimeSpan.FromHours(-5)), alert.Sent);
            //  <status>Actual</status>
            Assert.Equal(Status.Actual, alert.Status);
            //  <msgType>Alert</msgType>
            Assert.Equal(MessageType.Alert, alert.MessageType);
            //  <scope>Public</scope>
            Assert.Equal(Scope.Public, alert.Scope);
            //  <info>
            Assert.Equal(1, alert.Info.Count);
            var info = alert.Info.ElementAt(0);
            //    <category>Security</category>
            Assert.Equal(1, info.Categories.Count);
            Assert.Contains(Category.Security, info.Categories);
            //    <event>Homeland Security Advisory System Update</event>
            Assert.Equal("Homeland Security Advisory System Update", info.Event);
            //    <urgency>Immediate</urgency>
            Assert.Equal(Urgency.Immediate, info.Urgency);
            //    <severity>Severe</severity>
            Assert.Equal(Severity.Severe, info.Severity);
            //    <certainty>Likely</certainty>
            Assert.Equal(Certainty.Likely, info.Certainty);
            //    <senderName>U.S. Government, Department of Homeland Security</senderName>
            Assert.Equal("U.S. Government, Department of Homeland Security", info.SenderName);
            //    <headline>Homeland Security Sets Code ORANGE</headline>
            Assert.Equal("Homeland Security Sets Code ORANGE", info.Headline);
            //    <description>The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.</description>
            Assert.Equal("The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.", info.Description);
            //    <instruction>A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.</instruction>
            Assert.Equal("A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.", info.Instruction);
            //    <web>http://www.dhs.gov/dhspublic/display?theme=29</web>
            Assert.Equal(new Uri("http://www.dhs.gov/dhspublic/display?theme=29"), info.Web);
            //    <parameter>
            Assert.Equal(1, info.Parameters.Count);
            var parameter = info.Parameters.First();
            //      <valueName>HSAS</valueName>
            Assert.Equal("HSAS", parameter.ValueName);
            //      <value>ORANGE</value>
            Assert.Equal("ORANGE", parameter.Value);
            //    </parameter>
            //    <resource>
            Assert.Equal(1, info.Resources.Count);
            var resource = info.Resources.First();
            //      <resourceDesc>Image file (GIF)</resourceDesc>
            Assert.Equal("Image file (GIF)", resource.Description);
            //      <mimeType>image/gif</mimeType>
            Assert.Equal("image/gif", resource.MimeType);
            //      <size>1</size>
            Assert.Equal(1, resource.Size);
            //      <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            Assert.Equal(new Uri("http://www.dhs.gov/dhspublic/getAdvisoryImage"), resource.Uri);
            //      <derefUri>derefUri</derefUri>
            Assert.Equal("derefUri", resource.DereferencedUri);
            //      <digest>digest</digest>
            Assert.Equal("digest", resource.Digest);
            //    </resource>
            //    <area>
            Assert.Equal(1, info.Areas.Count);
            var area = info.Areas.First();
            //      <areaDesc>U.S. nationwide and interests worldwide</areaDesc>
            Assert.Equal("U.S. nationwide and interests worldwide", area.Description);
            //      <altitude>altitude</altitude>
            Assert.Equal(100, area.Altitude);
            //      <ceiling>ceiling</ceiling>
            Assert.Equal(120, area.Ceiling);

            //    </area>
            //  </info>
            //</alert>
        }

        [Fact]
        public void OrangeAlertExampleIsParsedCorrectly()
        {
            var alert = XmlParser.Parse(Xml.OrangeAlertXml).First();
            //<?xml version="1.0" encoding="utf-8"?>
            //<alert xmlns="urn:oasis:names:tc:emergency:cap:1.2">
            Assert.NotNull(alert);
            //  <identifier>43b080713727</identifier>
            Assert.Equal("43b080713727", alert.Identifier);
            //  <sender>hsas@dhs.gov</sender>
            Assert.Equal("hsas@dhs.gov", alert.Sender);
            //  <sent>2003-04-02T14:39:01-05:00</sent>
            Assert.Equal(new DateTimeOffset(2003, 4, 2, 14, 39, 1, TimeSpan.FromHours(-5)), alert.Sent);
            //  <status>Actual</status>
            Assert.Equal(Status.Actual, alert.Status);
            //  <msgType>Alert</msgType>
            Assert.Equal(MessageType.Alert, alert.MessageType);
            //  <scope>Public</scope>
            Assert.Equal(Scope.Public, alert.Scope);
            //  <info>
            Assert.Equal(1, alert.Info.Count);
            var info = alert.Info.ElementAt(0);
            //    <category>Security</category>
            Assert.Equal(1, info.Categories.Count);
            Assert.Contains(Category.Security, info.Categories);
            //    <event>Homeland Security Advisory System Update</event>
            Assert.Equal("Homeland Security Advisory System Update", info.Event);
            //    <urgency>Immediate</urgency>
            Assert.Equal(Urgency.Immediate, info.Urgency);
            //    <severity>Severe</severity>
            Assert.Equal(Severity.Severe, info.Severity);
            //    <certainty>Likely</certainty>
            Assert.Equal(Certainty.Likely, info.Certainty);
            //    <senderName>U.S. Government, Department of Homeland Security</senderName>
            Assert.Equal("U.S. Government, Department of Homeland Security", info.SenderName);
            //    <headline>Homeland Security Sets Code ORANGE</headline>
            Assert.Equal("Homeland Security Sets Code ORANGE", info.Headline);
            //    <description>The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.</description>
            Assert.Equal("The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.", info.Description);
            //    <instruction>A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.</instruction>
            Assert.Equal("A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.", info.Instruction);
            //    <web>http://www.dhs.gov/dhspublic/display?theme=29</web>
            Assert.Equal(new Uri("http://www.dhs.gov/dhspublic/display?theme=29"), info.Web);
            //    <parameter>
            Assert.Equal(1, info.Parameters.Count);
            var parameter = info.Parameters.First();
            //      <valueName>HSAS</valueName>
            Assert.Equal("HSAS", parameter.ValueName);
            //      <value>ORANGE</value>
            Assert.Equal("ORANGE", parameter.Value);
            //    </parameter>
            //    <resource>
            Assert.Equal(1, info.Resources.Count);
            var resource = info.Resources.First();
            //      <resourceDesc>Image file (GIF)</resourceDesc>
            Assert.Equal("Image file (GIF)", resource.Description);
            //      <mimeType>image/gif</mimeType>
            Assert.Equal("image/gif", resource.MimeType);
            //      <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
            Assert.Equal(new Uri("http://www.dhs.gov/dhspublic/getAdvisoryImage"), resource.Uri);
            //    </resource>
            //    <area>
            Assert.Equal(1, info.Areas.Count);
            var area = info.Areas.First();
            //      <areaDesc>U.S. nationwide and interests worldwide</areaDesc>
            Assert.Equal("U.S. nationwide and interests worldwide", area.Description);
            //    </area>
            //  </info>
            //</alert>
        }
    }
}