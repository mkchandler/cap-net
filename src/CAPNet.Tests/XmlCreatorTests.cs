using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;

using CAPNet.Models;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlCreatorTests
    {
        private const string Sender = "victorg@email.com";

        private static readonly DateTimeOffset Sent = new DateTimeOffset(
            2014,
            6,
            10,
            10,
            35,
            23,
            512,
            TimeSpan.FromHours(-3));

        private static readonly Alert Alert = new Alert
                                                  {
                                                      Identifier = Guid.NewGuid().ToString(),
                                                      Sender = Sender,
                                                      Sent = Sent,
                                                      Status = Status.Test,
                                                      MessageType = MessageType.Alert,
                                                      Scope = Scope.Private

                                                  };

        [Fact]
        public void XmlNodeReturnedHasCAP12Namespace()
        {
            XElement xmlElement = XmlCreator.Create(Alert);

            Assert.Equal("urn:oasis:names:tc:emergency:cap:1.2", xmlElement.Name.NamespaceName);
        }

        [Fact]
        public void XmlNodeReturnedHasSender()
        {
            var alertElement = XmlCreator.Create(Alert);

            var senderElement = alertElement.Element(XmlCreator.CAP12Namespace + "sender");

            Assert.NotNull(senderElement);
            Assert.Equal(Sender, senderElement.Value);
        }

        [Fact]
        public void XmlNodeReturnedHasStatus()
        {
            var alertElement = XmlCreator.Create(Alert);

            var statusElement = alertElement.Element(XmlCreator.CAP12Namespace + "status");

            Assert.NotNull(statusElement);
            Assert.Equal("Test", statusElement.Value);
        }

        [Fact]
        public void XmlNodeReturnedHasSentTime()
        {
            var alertElement = XmlCreator.Create(Alert);

            var sentElement = alertElement.Element(XmlCreator.CAP12Namespace + "sent");

            Assert.NotNull(sentElement);
            Assert.Equal("2014-06-10T10:35:23-03:00", sentElement.Value);
        }

        [Fact]
        public void ExampleOrangeAlertIsSerializedCorrectly()
        {
            var orangeAlertElement = XmlCreator.Create(CreateOrangeAlert());

            var document = new XDocument(orangeAlertElement);

            string alertAsString;
            var writerSettings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };
            using (var memoryStream = new MemoryStream())
            {
                var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8);
                using (var writer = XmlWriter.Create(streamWriter, writerSettings))
                {
                    document.Save(writer);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                alertAsString = new StreamReader(memoryStream, Encoding.UTF8).ReadToEnd();
            }

            Assert.Equal<string>(Examples.OrangeAlertXml, alertAsString);

        }

        private static Alert CreateOrangeAlert()
        {
            var orangeAlert = new Alert
            {
                //<?xml version = "1.0" encoding = "UTF-8"?>
                //<alert xmlns = "urn:oasis:names:tc:emergency:cap:1.2">
                //  <identifier>43b080713727</identifier>
                Identifier = "43b080713727",
                //  <sender>hsas@dhs.gov</sender>
                Sender = "hsas@dhs.gov",
                //  <sent>2003-04-02T14:39:01-05:00</sent>
                Sent = new DateTimeOffset(2003, 4, 2, 14, 39, 1, TimeSpan.FromHours(-5)),
                //  <status>Actual</status>
                Status = Status.Actual,
                //  <msgType>Alert</msgType>
                MessageType = MessageType.Alert,
                //  <scope>Public</scope>
                Scope = Scope.Public,
                //  <source>source</source>
                Source = "source",
                //   <restriction>restriction</restriction>
                Restriction = "restriction",
                //   <addresses>addresses</addresses>
                Addresses = "addresses",
                //   <code>code</code>
                Code = "code",
                //   <note>note</note>
                Note = "note",
                //   <references>references</references>
                References = "references",
                //   <incidents>incidents</incidents>
                Incidents = "incidents"

            };

            //  <info>
            var info = new Info();
            //    <category>Security</category>
            info.Categories.Add(Category.Security);
            //    <event>Homeland Security Advisory System Update</event>
            info.Event = "Homeland Security Advisory System Update";
            //    <responsetype>Shelter</responsetype>
            info.ResponseType = "Shelter";
            //    <urgency>Immediate</urgency>
            info.Urgency = Urgency.Immediate;
            //    <severity>Severe</severity>
            info.Severity = Severity.Severe;
            //    <certainty>Likely</certainty>
            info.Certainty = Certainty.Likely;
            //    <audience>audience</audience>
            info.Audience = "audience";
            //<eventcode>
            //  <valuename>valN</valuename>
            //  <value>val</value>
            //</eventcode>
            info.EventCodes.Add(new EventCode("valN", "val"));
            info.EventCodes.Add(new EventCode("valN1", "val1"));
            //  <effective>2003-04-02T14:39:01-05:00</effective>
            info.Effective = new DateTimeOffset(2003, 4, 2, 14, 39, 1, TimeSpan.FromHours(-5));
            //  <onset>2003-04-02T14:39:01-05:00</onset>
            info.Onset = new DateTimeOffset(2003, 4, 2, 14, 39, 1, TimeSpan.FromHours(-5));
            //  <expires>2003-04-02T14:39:01-05:00</expires>
            info.Expires = new DateTimeOffset(2003, 4, 2, 14, 39, 1, TimeSpan.FromHours(-5));
            //    <senderName>U.S. Government, Department of Homeland Security</senderName>
            info.SenderName = "U.S. Government, Department of Homeland Security";
            //    <headline>Homeland Security Sets Code ORANGE</headline>
            info.Headline = "Homeland Security Sets Code ORANGE";
            //    <description>The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.</description>
            info.Description = "The Department of Homeland Security has elevated the Homeland Security Advisory System threat level to ORANGE / High in response to intelligence which may indicate a heightened threat of terrorism.";
            //    <instruction>A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.</instruction> 
            info.Instruction = "A High Condition is declared when there is a high risk of terrorist attacks. In addition to the Protective Measures taken in the previous Threat Conditions, Federal departments and agencies should consider agency-specific Protective Measures in accordance with their existing plans.";
            //    <web>http://www.dhs.gov/dhspublic/display?theme=29</web>
            info.Web = "http://www.dhs.gov/dhspublic/display?theme=29";
            //    <contact>contact</contact>
            info.Contact = "contact";
            //    <parameter>
            //      <valueName>HSAS</valueName>
            //      <value>ORANGE</value>
            //    </parameter>
            info.Parameters.Add(new Parameter("HSAS", "ORANGE"));
            //    <resource>
            info.Resources.Add(new Resource
            {
                //      <resourceDesc>Image file (GIF)</resourceDesc>
                Description = "Image file (GIF)",
                //      <mimeType>image/gif</mimeType>
                MimeType = "image/gif",
                //      <uri>http://www.dhs.gov/dhspublic/getAdvisoryImage</uri>
                Uri = "http://www.dhs.gov/dhspublic/getAdvisoryImage"
            //    </resource>
            });

            List<GeoCode> geocodeList = new List<GeoCode>();
            geocodeList.Add(new GeoCode("valN","val"));
            geocodeList.Add(new GeoCode("valN1", "val1"));

            info.Areas.Add(
                //  <area>
                new Area
                {
                    //  <areaDesc>U.S. nationwide and interests worldwide</areaDesc>
                    Description = "U.S. nationwide and interests worldwide",
                    //  <altitude>altitude</altitude>
                    Altitude = "altitude",
                    //  <ceiling>ceiling</ceiling>
                    Ceiling = "ceiling",
                    //<geocode>
                    //  <valueName>valN</valueName>
                    //  <value>val</value>
                    //</geocode>
                    //<geocode>
                    //  <valueName>valN1</valueName>
                    //  <value>val1</value>
                    //</geocode>
                    Geocodes = geocodeList         

                    //  </area>
                });
            //  </info>

            orangeAlert.Info.Add(info);
            //</alert>
            return orangeAlert;
        }
    }
}
