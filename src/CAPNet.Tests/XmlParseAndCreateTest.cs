using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

using CAPNet.Models;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlParseAndCreateTest
    {
        [Fact]
        public void OrangeAlertXmlGeneralTest()
        {
            string xmlContent = Xml.OrangeAlertXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleCircleXmlGeneralTest()
        {
            string xmlContent = Xml.MultipleCircleXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleParameterXmlGeneralTest()
        {
            string xmlContent = Xml.MultipleParameterTestXml;
            string correctedXmlContent = xmlContent.Replace("Very Likely", "Likely");
            XDocument originalDocument = XDocument.Parse(correctedXmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void ThunderStorm12AllDatesXmlGeneralTest()
        {
            string xmlContent = Xml.Thunderstorm12AllDatesXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void AllElementsFilledXmlGeneralTest()
        {
            string xmlContent = Xml.AllElementsFilledAlert;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void SevereThunderStormCap11GeneralTest()
        {
            string xmlContent = Xml.SevereThundertromCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void HomeLandSecurityAlertCap11GeneralTest()
        {
            string xmlContent = Xml.HomeLandSecurityAlertCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void EarthquakeCap11GeneralTest()
        {
            string xmlContent = Xml.EarthquakeCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void AmberGeneralTest()
        {
            string xmlContent = Xml.AmberAlertCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleThunderstorm12GeneralTest()
        {
            string xmlContent = Xml.MultipleThunderstorm12Xml;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            IEnumerable<Alert> alerts = XmlParser.Parse(xmlContent);
            IEnumerable<XElement> createdElements = XmlCreator.Create(alerts);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(new XElement(originalDocument.Root.Name.ToString(), createdElements));

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }


    }
}
