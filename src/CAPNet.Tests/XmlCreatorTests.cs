using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

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

            // compare just the beginning for now, we don't serialize the info elements yet
            Assert.Equal(Examples.OrangeAlertXml, alertAsString);
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
                Scope = Scope.Public
            };

            //  <info>
            var info = new Info();
            //    <category>Security</category>
            info.Categories.Add(Category.Security);
            //    <event>Homeland Security Advisory System Update</event>
            info.Event = "Homeland Security Advisory System Update";
            //    <urgency>Immediate</urgency>
            info.Urgency = "Immediate";
            //    <severity>Severe</severity>
            info.Severity = Severity.Severe;
            //    <certainty>Likely</certainty>
            info.Certainty = "Likely";
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
            //    <parameter>
            //      <valueName>HSAS</valueName>
            //      <value>ORANGE</value>
            //    </parameter>
            info.Parameters.Add("HSAS", "ORANGE");
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
            info.Areas.Add(
                //  <area>
                new Area
                {
                    //  <areaDesc>U.S. nationwide and interests worldwide</areaDesc>
                    Description = "U.S. nationwide and interests worldwide"
                //  </area>
                });
            //  </info>

            orangeAlert.Info.Add(info);
            //</alert>
            return orangeAlert;
        }
    }
}
